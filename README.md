# Selenium Tests for Bühler Insights

## Prerequisites
- .NET Core 2.1+ installed
- Chrome / Firefox Browser installed

## How to start with Visual Studio 2017+

1. Clone git repository
2. Open solution _Buhler.IoT.e2e.sln_ in Visual Studio 2017+
3. Open file _e2e.runsettings_ and enter url and credentials
4. Go to _Test => Test Settings => Select Test Settings File_
5. Select file _e2e.runsettings_
6. Go to test explorer and run tests

## How to start with command line

1. Clone git repository 
2. Open file _e2e.runsettings_ and enter url and credentials
3. Open command shell
4. Go to root directory where _Buhler.IoT.e2e.sln_ is located
5. Run command: ```dotnet test -s e2e.runsettings```
