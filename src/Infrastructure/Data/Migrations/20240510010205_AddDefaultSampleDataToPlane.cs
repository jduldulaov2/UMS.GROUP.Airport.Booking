using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultSampleDataToPlane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Plane",
            columns: new[] { "AirlineName", "Code", "Model", "UniqueId", "Created", "CreatedBy", "LastModified", "LastModifiedBy"},
            values: new object[,]
            {
                { "Philippine Airlines", "PAL123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "Cebu Pacific", "CBP123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "Air Asia", "ASIA123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "Singapore Airlines", "SG123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "Qatar Airways", "QA123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "Emirates", "EM123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "ANA All Nippon Airways", "ANA123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "Qantas Airways", "QA231", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "Japan Airlines", "JA123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "Air France", "AF123", "Airbus a321", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
