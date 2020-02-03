# Overflow Calculator

A tool to find the volume of a glass in a pyramid.

## Build and Run

### .NET CLI

1. Build

```
	dotnet test "overflow.test\overflow.test.csproj" -c Release

	dotnet publish "overflow.exe\overflow.exe.csproj" -c Release -o bin
```

2. Run

```
	dotnet bin\overflow.exe.dll --row 3 --index 2 --poured 10
```

### Docker

1. Create image
```
	docker build -f "overflow.exe\Dockerfile" . -t overflow:dev
```

2. Run image
```
	docker run -t overflow:dev -- --row 3 --index 2 --poured 10
```
