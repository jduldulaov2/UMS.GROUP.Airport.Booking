# UMS.GROUP.Airport.Booking

The project was generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/UMS.GROUP.Airport.Booking) version 8.0.4.

The architectural pattern used on this project is CQRS

CQRS separates reads and writes into different models, using commands to update data, and queries to read data.

The Front-end used is Angular 16

## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Code Scaffolding

The template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.