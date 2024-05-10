using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultSampleDataToAirport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Airport",
            columns: new[] { "AirportName", "Street", "City", "Province", "Region", "ZipCode", "UniqueId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "CountryId" },
            values: new object[,]
            {
                { "Davao City International Airport", "Davao", "Davao City", "Davao Del Sur", "Region 11", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "1" },
                { "NAIA International Airport", "Pasay", "Pasay City", "Metro Manila", "Region 1", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "1" },
                { "Clark Pampanga Airport", "Pampanga", "Pampanga City", "Metro Manila", "Region 2", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "1" },
                { "Ilo Ilo Airport", "Ilo Ilo", "Ilo-Ilo City", "Ilo-Ilo", "Region 3", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "1" },
                { "Cagayan de Oro International Airport", "Cagayan", "Cagayan de Oro City", "Cagayan de Oro", "Region 4", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "1" },
                { "Ozamis International Airport", "Ozamis", "Ozamis City", "Ozamis City", "Region 6", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "1" },

                { "Phoenix Sky Harbor International Airport", "Phoenix", "Phoenix", "Phoenix", "Phoenix", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "2" },
                { "Northwest Arkansas National Airport", "Arkansas", "Arkansas City", "Arkansas", "Arkansas 1", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "2" },
                { "California Redwood Coast–Humboldt County Airport", "California", "California City", "California", "California 2", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "2" },
                { "San Francisco International Airport", "San Francisco", "San Francisco", "San Francisco", "San Francisco 3", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "2" },
                { "Denver International Airport", "Denver", "Denver", "Denver", "Denver 4", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "2" },
                { "Bradley International Airport", "Bradley", "Bradley", "Bradley City", "Region 6", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "2" },

                { "Abha International Airport", "Abha", "Abha", "Abha", "Abha", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "3" },
                { "Al-Hofuf, Al-Ahsa International Airport", "Al-Hofuf", "Al-Hofuf City", "Al-Hofuf", "Al-Hofuf 1", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "3" },
                { "Buraidah International Airport", "Buraidah", "Buraidah City", "Buraidah", "Buraidah 2", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "3" },
                { "Jeddah International Airport", "Jeddah", "Jeddah", "Jeddah", "Jeddah", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "3" },
                { "Riyadh International Airport", "Riyadh", "Riyadh", "Riyadh", "Riyadh 4", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "3" },
                { "Yanbu International Airport", "Yanbu", "Yanbu", "Yanbu City", "Yanbu 6", "8000", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system", "3" },

            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
