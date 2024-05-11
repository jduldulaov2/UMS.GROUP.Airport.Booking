using System.Globalization;
using UMS.GROUP.Airport.Booking.Application.Auth.Commands.Login;
using UMS.GROUP.Airport.Booking.Application.Auth.Commands.Logout;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.Users.Commands.CreateUser;
using UMS.GROUP.Airport.Booking.Application.Users.Commands.UpdatePassword;
using UMS.GROUP.Airport.Booking.Application.Users.Commands.UpdateUser;
using UMS.GROUP.Airport.Booking.Application.Users.Queries.GetUserByID;
using UMS.GROUP.Airport.Booking.Application.Users.Queries.GetUsers;
using UMS.GROUP.Airport.Booking.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UMS.GROUP.Airport.Booking.Application.Auth.Queries.GetLoggedIn;
namespace UMS.GROUP.Airport.Booking.Infrastructure.Identity;


public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly IJsonService _jsonService;
    private readonly IUser _user;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService, 
        SignInManager<ApplicationUser> signInManager, IJsonService jsonService,
        IUser user
        )
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _signInManager = signInManager;
        _jsonService = jsonService;
        _user = user;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string? userId, string? role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role?? "");
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<List<string>> GetUserRoles(string userId)
    {
        var roles = new List<string>();

        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user is not null)
        {
            var result = await _userManager.GetRolesAsync(user);

            roles = result.ToList();

        }

        return roles;

    }

    public async Task<bool> IsValidCredential(string username, string password)
    {
        var isValid = false;

        var credential = await _userManager.FindByEmailAsync(username);
        var result = await _signInManager.PasswordSignInAsync(username, password, false, true);

        if (credential != null && result.Succeeded)
        {
            isValid = true;
        }

        return isValid;
    }

    public async Task<Result<UsersListDto>> AllUsersByName(string username)
    {
        var userList = new List<UsersDto>();

        var entity = await _userManager.Users.Where(u => u.LastName == username).ToListAsync();

        if (String.IsNullOrEmpty(username))
        {
            entity = await _userManager.Users.ToListAsync();
        }

        if (entity != null && entity.Count > 0)
        {
            foreach (var users in entity)
            {
                bool isAdminRole = await this.IsInRoleAsync(users.Id, Roles.Administrator);

                var dtoList = new UsersDto()
                {
                    Id = users.Id,
                    Avatar = StringInfo.GetNextTextElement(users.FirstName!, 0).ToUpper() + "" + StringInfo.GetNextTextElement(users.LastName!, 0).ToUpper(),
                    UserName = users.UserName,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    MiddleName = users.MiddleName,
                    EmailAddress = users.Email,
                    IsAdminAccount = isAdminRole,
                    Street = users.Street,
                    City = users.City,
                    Province = users.Province,
                    Region = users.Region,
                    ZipCode = users.ZipCode,
                    ContactNumber = users.ContactNumber

                };
                userList.Add(dtoList);
            }

            return new()
            {
                Data = new UsersListDto
                {
                    Users = userList
                },
                Message = "Records Found.",
                ResultType = ResultType.Success,
            };
        }
        
        return new()
        {
            Data = new UsersListDto{ },
            Message = "No Records Found.",
            ResultType = ResultType.Error,
        };
    }

    public async Task<bool> IsValidUserId(string userid)
    {
        var isValid = false;

        var credential = await _userManager.FindByIdAsync(userid);

        if (credential != null)
        {
            isValid = true;
        }

        return isValid;
    }

    public async Task<UserByIDDto> UserDetails(string userid)
    {
        var credential = await _userManager.FindByIdAsync(userid);

        return new UserByIDDto()
        {
            Id = credential!.Id,
            Avatar = StringInfo.GetNextTextElement(credential.FirstName!, 0).ToUpper() + "" + StringInfo.GetNextTextElement(credential.LastName!, 0).ToUpper(),
            UserName = credential.UserName,
            LastName = credential.LastName,
            FirstName = credential.FirstName,
            MiddleName = credential.MiddleName,
            EmailAddress = credential.MiddleName,
            Street = credential.Street,
            City = credential.City,
            Province = credential.Province,
            Region = credential.Region,
            ZipCode = credential.ZipCode,
            ContactNumber = credential.ContactNumber
        };
    }

    public async Task<Result<LoginDto>> LoginAsync(string? username, string? password, bool isPersistent = false, bool lockOutOnFailure = false)
    {
        var signInResult =  await _signInManager.PasswordSignInAsync(username ?? "", password ?? "", isPersistent, lockOutOnFailure);

        if (signInResult.Succeeded)
        {
            var signInDetails = await _userManager.FindByNameAsync(username ?? "");

            var administratorRole = await this.IsInRoleAsync(signInDetails?.Id, Roles.Administrator);

            return new()
            {
                Data = new LoginDto
                {
                    Id = signInDetails?.Id,
                    UserName = signInDetails?.UserName,
                    LastName = signInDetails?.LastName,
                    FirstName = signInDetails?.FirstName,
                    MiddleName = signInDetails?.MiddleName,
                    EmailAddress = signInDetails?.Email,
                    IsAdminAccount = administratorRole,
                    Street = signInDetails?.Street,
                    City = signInDetails?.City,
                    Province = signInDetails?.Province,
                    Region = signInDetails?.Region,
                    ZipCode = signInDetails?.ZipCode,
                    ContactNumber = signInDetails?.ContactNumber
                },
                Message = "login successful",
                ResultType = ResultType.Success,
            };
        }

        return new() {
            Data = new LoginDto
            {
            },
            Message = "Username or password is incorrect.",
            ResultType = ResultType.Error,
        };
    }

    public async Task<Result<LogoutDto>> LogOut(string? userid)
    {
        var signInDetails = await _userManager.FindByIdAsync(userid ?? "");

        if (signInDetails != null)
        {
            await _signInManager.SignOutAsync();

            return new()
            {
                Data = new LogoutDto
                {
                    UserId = signInDetails?.Id,
                    Time = DateTime.Now
                },
                Message= "logoff successful",
                ResultType = ResultType.Success
            };
        }

        return new()
        {
            Data = new LogoutDto{ },
            Message = "failed logoff",
            ResultType = ResultType.Error
        };
    }

    public async Task<Result<CreateUserDto>> CreateIdentityUserAsync(string? userName, string? password, string? lastName, string? firstName, string? middleName, string? emailAddress, string? street, string? city, string? province, string? region, string? zipCode, string? contactNumber)
    {
        var isUsernameExist = await _userManager.FindByNameAsync(userName ?? "");

        if (isUsernameExist == null)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                LastName = lastName,
                FirstName = firstName,
                MiddleName = middleName,
                Email = emailAddress,
                NormalizedEmail = emailAddress,
                Street = street,
                City = city,
                Province = province,
                Region = region,
                ZipCode = zipCode,
                ContactNumber = contactNumber
            };

            await _userManager.CreateAsync(user, password!);

            var validateUser = await _userManager.FindByNameAsync(userName!);
            var validateAdministratorRole = await this.IsInRoleAsync(validateUser?.Id, Roles.Administrator);

            return new()
            {
                Data = new CreateUserDto
                {
                    Id = validateUser?.Id,
                    UserName = userName,
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    EmailAddress = emailAddress,
                    IsAdminAccount = validateAdministratorRole,
                    Street = street,
                    City = city,
                    Province = province,
                    Region = region,
                    ZipCode = zipCode,
                    ContactNumber = contactNumber
                },
                Message = "New user has been successfully added.",
                ResultType = ResultType.Success
            };
        }

        return new()
        {
            Data = new CreateUserDto
            {
            },
            Message = "User with the same details already exist.",
            ResultType = ResultType.Error
        };


    }

    public async Task<Result<UpdateUserDto>> UpdateIdentityUserAsync(string? id, string? userName, string? lastName, string? firstName, string? middleName, string? emailAddress, string? street, string? city, string? province, string? region, string? zipCode, string? contactNumber)
    {
        var user = await _userManager.FindByIdAsync(id ?? "");

        var checkIfUserNameExist = await _userManager.Users.Where(u => u.UserName == userName && u.UserName != user!.UserName).ToListAsync();

        //Username already exist on other accounts
        if (checkIfUserNameExist.Count > 0)
        {
            return new()
            {
                Data = new UpdateUserDto
                {
                },
                Message = "Username already exist.",
                ResultType = ResultType.Error
            };
        }

        if (user != null)
        {
            user.UserName = userName;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.MiddleName = middleName;
            user.Email = emailAddress;
            user.Street = street;
            user.City = city;
            user.Province = province;
            user.Region = region;
            user.ZipCode = zipCode;
            user.ContactNumber = contactNumber;

            await _userManager.UpdateAsync(user);

            return new()
            {
                Data = new UpdateUserDto
                {
                    Id = user.Id,
                    UserName = userName,
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    EmailAddress = emailAddress,
                    Street = street,
                    City = city,
                    Province = province,
                    Region = region,
                    ZipCode = zipCode,
                    ContactNumber = contactNumber
                },
                Message = "Record has been successfully updated.",
                ResultType = ResultType.Success
            };
        }

        return new()
        {
            Data = new UpdateUserDto
            {
            },
            Message = "record does not exist.",
            ResultType = ResultType.Error
        };
    }

    public async Task<Result<UpdatePasswordDto>> UpdateIdentityUserPasswordAsync(string? userName, string? oldPassword, string? newPassword)
    {
        var user = await _userManager.FindByNameAsync(userName ?? "");

        var validateCredentials = await _userManager.CheckPasswordAsync(user!, oldPassword!);

        if (validateCredentials)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user!);

            await _userManager.ResetPasswordAsync(user!, token, newPassword!);

            return new()
            {
                Data = new UpdatePasswordDto
                {
                    Id = user!.Id,
                    UpdatedDate = DateTime.Now
                },
                Message = "Password has been updated.",
                ResultType = ResultType.Success
            };
        }

        return new()
        {
            Data = new UpdatePasswordDto
            {
            },
            Message = "Account does not exist.",
            ResultType = ResultType.Error
        };
    }

    public async Task<Result<UserByIDDto>> GetUserById(string? id)
    {
        var credential = await IsValidUserId(id!);

        if (credential == false)
        {
            return new()
            {
                Data = new UserByIDDto() { },
                Message = "Record not found.",
                ResultType = ResultType.Error
            };
        }
        else
        {
            var usercredential = await _userManager.FindByIdAsync(id!);

            var administratorRole = await IsInRoleAsync(usercredential!.Id, Roles.Administrator);

            return new()
            {
                Data = new UserByIDDto()
                {
                    Id = usercredential.Id,
                    Avatar = StringInfo.GetNextTextElement(usercredential.FirstName!, 0).ToUpper() + "" + StringInfo.GetNextTextElement(usercredential.LastName!, 0).ToUpper(),
                    UserName = usercredential.UserName,
                    LastName = usercredential.LastName,
                    FirstName = usercredential.FirstName,
                    MiddleName = usercredential.MiddleName,
                    EmailAddress = usercredential.Email,
                    IsAdminAccount = administratorRole,
                    Street = usercredential.Street,
                    City = usercredential.City,
                    Province = usercredential.Province,
                    Region = usercredential.Region,
                    ZipCode = usercredential.ZipCode,
                    ContactNumber = usercredential.ContactNumber
                },
                Message = "Record found.",
                ResultType = ResultType.Success
            };
        }
    }

    public async Task<Result<GetLoggedInQueryDto>> GetLoggedIn()
    {
        string userDetail = await Task.Run(() => GetLoggedInUser());

        if (userDetail != null)
        {
            return new()
            {
                Data = new GetLoggedInQueryDto
                {
                    LoggedInId = userDetail
                },
                Message = "Logged in user detected",
                ResultType = ResultType.Success
            };
        }

        return new()
        {
            Data = new GetLoggedInQueryDto
            {
            },
            Message = "Logged in not detected",
            ResultType = ResultType.Error
        };

    }

    private string GetLoggedInUser()
    {
        return _user.Id!;
    }
}
