using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultSampleDataToFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Flight",
            columns: new[] { "FlightCode", "AirportId", "PlaneId", "UniqueId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
            values: new object[,]
            {
                { "FL0001", "1", "1", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0002", "1", "2", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0003", "1", "3", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0004", "1", "4", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0005", "1", "5", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},

                { "FL0006", "2", "6", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0007", "2", "7", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0008", "2", "8", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0009", "2", "9", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL00010", "2", "10", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},

                { "FL0011", "3", "5", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0012", "3", "4", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0013", "3", "3", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0014", "3", "2", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0015", "3", "1", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},

                { "FL0016", "4", "1", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0017", "7", "3", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0018", "3", "5", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0019", "9", "8", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "FL0020", "8", "9", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"}

            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
