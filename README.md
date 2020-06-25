# NETCore2Blockly

<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-4-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->
[![Build Status](https://dev.azure.com/ignatandrei0674/NETCoreBlockly/_apis/build/status/ignatandrei.NETCoreBlockly?branchName=master)](https://dev.azure.com/ignatandrei0674/NETCoreBlockly/_build?definitionId=9)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/ignatandrei/NetCore2Blockly/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/NetCore2Blockly.svg)](https://www.nuget.org/packages/NetCore2Blockly)
![Generate Thanks Outdated Licenses](https://github.com/ignatandrei/NETCoreBlockly/workflows/.NET%20Core/badge.svg)

# What it does
NETCore2Blockly generates [Blockly](https://developers.google.com/blockly) blocks for each of your controller actions. 

Demo at https://netcoreblockly.herokuapp.com/ ( play with the links from the bottom)

Demo Video at https://www.youtube.com/watch?v=GptkNWjmCzk

Sample Project is TestBlocklyHtml from this repository

# How to install NETCore2Blockly in a .NET Core 3.1  WebAPI / MVC application

## Step 1:
Install https://www.nuget.org/packages/NetCore2Blockly/ by running the following command in the Package Manager Console:
> Install-Package NetCore2Blockly

## Step 2:
Modify Startup.cs by adding
```csharp
public void ConfigureServices(IServiceCollection services)
        {
            //last line
            services.AddBlockly();
        }
public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        //if you plan to use as html, do not forget app.UseStaticFiles
        //last line
        app.UseBlockly(); 
}
```

## Step 3:

To see the UI , please add
```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
       
       app.UseBlocklyUI(); // you can customize (with BlocklyUIOptions argument )header name, start blocks, others... 
       //you can add  storage like local storage or sqlite 
       //app.UseBlocklyLocalStorage();
       //app.UseBlocklySqliteStorage() ; // other nuget package
       app.UseBlockly();
}
```

### For Swagger ( local or remote )

app.UseBlocklySwagger("petstore", "https://petstore.swagger.io/v2/swagger.json")


### For ODATA ( local or remote)

app.UseBlocklyOData("OdataV4", "https://services.odata.org/TripPinRESTierService/");

### For GraphQL

app.UseBlocklyGraphQL("localGraphql", "/graphql");


## For authentication 
 
See links 22 for JWT and 31 for Auth0  from https://netcoreblockly.herokuapp.com/ 

## Step 4:

Run the application and browse to  /blockly.html

That's all!


## More information

Download the source code, run the TestBlocklyHtml project ( in the test folder ).

See there 

 region blockly needed

and

 region blockly optional 


and follow the code.

All other code is just boilerplate for Swagger, OData,GraphQL that are mandataory for demo'ing the application, not for Blockly2NetCore itself.

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

If you want to contribute, that is plenty of work to be done -see issues tab .

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="http://www.chestiiautomate.ro/"><img src="https://avatars1.githubusercontent.com/u/4983185?v=4" width="100px;" alt=""/><br /><sub><b>Cosmin Popescu</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=cosminpopescu14" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/adriannasui"><img src="https://avatars3.githubusercontent.com/u/8627433?v=4" width="100px;" alt=""/><br /><sub><b>Adrian Nasui</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=adriannasui" title="Documentation">📖</a></td>
    <td align="center"><a href="https://github.com/tudorgbiliescu"><img src="https://avatars3.githubusercontent.com/u/8693567?v=4" width="100px;" alt=""/><br /><sub><b>Tudor Iliescu</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=tudorgbiliescu" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/robertszabobv"><img src="https://avatars0.githubusercontent.com/u/9404144?v=4" width="100px;" alt=""/><br /><sub><b>robertszabobv</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=robertszabobv" title="Code">💻</a></td>
  </tr>
</table>

<!-- markdownlint-enable -->
<!-- prettier-ignore-end -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!

