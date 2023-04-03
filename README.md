# APIwithTest
WebAPI project with unit tests

## Initialization
At the begining of the repo, I need to create a set of rules to ensure that the main branches will contain only functional code, this means that at least all de Unit Test cases must pass before merging.
To do this, follow the next steps:
1. Clic "Actions". (If it's the first workflow, iss selected the desired, in this case I chose "Greetings" to give welcome to each new contributor).
2. Else, choice "New workflow" and next the required template, to me was ".NET", and below I put the corresponding YAML, which I modified tomodifiqué para ejecutarse en los "push" de ramas en "feature" y en los "pull request" hacia "develop"
----------------------------------------------
name: .NET build and test
on:
  push:
    branches: [ "feature/*" ]
  pull_request:
    branches: [ "develop" ]
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 6.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Test
      run: dotnet test --no-build --verbosity normal

## Start working
Once downloaded/cloned the repository, in the local machine is needed run **git flow init** and accept all the default configurations, the goal is to ease the handle of branches and changes.

## Releasing
To do an automated release, it's required to create a new rule thorugh *Github Actions*
