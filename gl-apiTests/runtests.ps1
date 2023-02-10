	# run tests and generate code coverage report
    dotnet test --collect:"XPlat Code Coverage"
	reportgenerator -reports:./TestResults/**/coverage.cobertura.xml -targetdir:./TestCodeCoverage /p:ExcludeByFile="**/program.cs"
    