using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultDataToCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Country",
            columns: new[] { "CountryName", "CountryCode", "Description", "UniqueId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
            values: new object[,]
            {
                { "Philippines", "PH", "Land of Promise", Guid.NewGuid().ToString(), DateTime.Now, "system", DateTime.Now, "system"},
                { "United States of America", "US", "US", Guid.NewGuid().ToString(), DateTime.Now, "system", DateTime.Now, "system"},
                { "Saudi Arabia", "KSA", "KSA", Guid.NewGuid().ToString(), DateTime.Now, "system", DateTime.Now, "system"},
                { "Singapore", "SG", "SG", Guid.NewGuid().ToString(), DateTime.Now, "system", DateTime.Now, "system"},
                { "United Arab Emirates", "UAE", "UAE", Guid.NewGuid().ToString(), DateTime.Now, "system", DateTime.Now, "system"},
                { "London", "LD", "LD", Guid.NewGuid().ToString(), DateTime.Now, "system", DateTime.Now, "system"},
                { "Australia", "AU", "AU", Guid.NewGuid().ToString(), DateTime.Now, "system", DateTime.Now, "system"},
                { "New Zealand", "NZ", "NZ", Guid.NewGuid().ToString(), DateTime.Now, "system", DateTime.Now, "system"}
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
