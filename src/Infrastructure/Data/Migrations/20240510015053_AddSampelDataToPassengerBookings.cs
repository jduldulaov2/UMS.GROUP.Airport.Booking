using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSampelDataToPassengerBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "PassengerBooking",
            columns: new[] { 
                "FlightId", 
                "FlightDate", 
                "Origin", 
                "Destination", 
                "FirstName", 
                "LastName", 
                "MiddleName", 
                "Street", 
                "City", 
                "Province", 
                "Region", 
                "ZipCode", 
                "ContactNumber", 
                "UniqueId", 
                "Created", 
                "CreatedBy", 
                "LastModified", 
                "LastModifiedBy" },
            values: new object[,]
            {
                { "1", DateTime.Now.AddDays(1), "Davao City", "Metro Manila", "Jake", "Dela Cruz", "Pratz", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "09989998728", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "2", DateTime.Now.AddDays(2), "Davao City", "Metro Manila", "James", "Barbaro", "Dumpit", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "09998877627", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "3", DateTime.Now.AddDays(3), "Davao City", "Metro Manila", "Johny", "Gonzales", "Fajerga", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "09665577829", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "4", DateTime.Now.AddDays(4), "Davao City", "Metro Manila", "Gaverell", "Abergas", "Painaga", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "09778862739", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "5", DateTime.Now.AddDays(5), "Davao City", "Metro Manila", "Kamille", "Brizuella", "Barreto", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "0988761144526", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},

                { "6", DateTime.Now.AddDays(6), "Davao City", "Cagayan de Oro", "Lizel", "Afrada", "Arroyo", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "09989998728", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "7", DateTime.Now.AddDays(7), "Davao City", "Cagayan de Oro", "Marrie", "Hurado", "Estrada", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "09998877627", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "8", DateTime.Now.AddDays(8), "Davao City", "Cagayan de Oro", "Connie", "Bonga", "Aquino", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "09665577829", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "9", DateTime.Now.AddDays(9), "Davao City", "Cagayan de Oro", "Ceceil", "Gido", "Duterte", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "09778862739", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"},
                { "10", DateTime.Now.AddDays(10), "Davao City", "Cagayan de Oro", "Rose", "Teodoro", "Ramos", "Deca Homes Indangan Cactus Street", "Davao City", "Davao Del Sur", "Region 11", "8000", "0988761144526", Guid.NewGuid().ToString(),  DateTime.Now, "system", DateTime.Now, "system"}
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
