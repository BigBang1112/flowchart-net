# Flowchart.NET

A web-based tool for creating flowcharts, developed as part of my Bachelor's thesis.

- **Title of Thesis:** Development of a Web Application for Creating and Editing Flowcharts
- **Thesis supervisor:** Mgr. Radim Remeš, Ph.D.

![Preview](preview.png)

## Features

- 4 symbols - Terminal, Process, I/O, Decision
- Drag & Drop system for symbols
- Full state import & export (except simulation state)
- Simulation support
- Code generation

## Technicals

- Libraries used:
  - [LeaderLine](https://github.com/anseki/leader-line) for drawing lines
  - [NCalc](https://github.com/ncalc/ncalc) for expression evaluation
  - [BlazorMonaco](https://github.com/serdarciplak/BlazorMonaco) for simple code view
- TypeScript modules
- Auto-deployed to GitHub Pages

The app was integrated into Blazor WebAssembly from a Razor component library project.

## Build

Make sure you have **.NET 9 SDK** and **.NET WebAssembly Build Tools** installed.

In **Visual Studio 2022**, you have to install the WASM build tools additionally as well.

In Visual Studio, you can just use Build Solution and everything should build.

In .NET CLI, run `dotnet build` on the solution (`.sln`) level.

## License

The project is GNU GPL v3 licensed.
