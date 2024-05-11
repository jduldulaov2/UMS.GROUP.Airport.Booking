using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataPassengerBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#E93B8B' WHERE Id=1");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#AF77E3' WHERE Id=2");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#5985DE' WHERE Id=3");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#7ED37B' WHERE Id=4");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#2ED6EE' WHERE Id=5");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#3F8FAB' WHERE Id=6");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#E93B8B' WHERE Id=7");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#E93B8B' WHERE Id=8");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#AF77E3' WHERE Id=9");
            migrationBuilder.Sql("UPDATE PassengerBooking SET AvatarColor = '#5985DE' WHERE Id=10");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
