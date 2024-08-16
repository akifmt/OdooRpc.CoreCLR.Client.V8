<a name="readme-top"></a>

<br />
<div align="center">
  
  <h3 align="center">OdooRpc.CoreCLR.Client.V8</h3>

  <p align="center">
    Simple Odoo JSON-RPC Client for .NET 8
    <br />
        <a href="#installation"><strong>Install »</strong></a>
    <br />
    <br />
    <a href="https://github.com/akifmt/OdooRpc.CoreCLR.Client.V8/issues">Report Bug</a>
    ·
    <a href="https://github.com/akifmt/OdooRpc.CoreCLR.Client.V8/issues">Request Feature</a>
  </p>
</div>

![version](https://img.shields.io/github/v/release/akifmt/OdooRpc.CoreCLR.Client.V8?color=blue)
![Downloads](https://img.shields.io/github/downloads/akifmt/OdooRpc.CoreCLR.Client.V8/total) ![Contributors](https://img.shields.io/github/contributors/akifmt/OdooRpc.CoreCLR.Client.V8?color=dark-green) ![Issues](https://img.shields.io/github/issues/akifmt/OdooRpc.CoreCLR.Client.V8) [![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)]()

<!-- ABOUT THE PROJECT -->
## About The Project

OdooRpc.CoreCLR.Client.V8
* Simple Odoo JSON-RPC Client for .NET 8
* Compatible with Odoo Version 17 (Released November, 2023)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Installation
<a name="installation"></a>

### Install
  - Check provided options from NuGet:
  - [https://www.nuget.org/packages/OdooRpc.CoreCLR.Client.V8](https://www.nuget.org/packages/OdooRpc.CoreCLR.Client.V8) 

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Usage
<a name="usage"></a>
We will create a custom model that extends the existing ProductProduct class, allowing us to interact with Odoo's product data more effectively. We will also include the necessary NuGet packages, a detailed explanation of the code, and how to make requests using the custom model.  
Steps:  
1. Adding Required Libraries
2. Creating a Child Class
3. Making Requests with the Custom Model

#### 1. Adding Required Libraries
You need to add the following packages to your .csproj file:
```
<ItemGroup>
    <PackageReference Include="OdooRpc.CoreCLR.Client.V8" Version="8.0.4" />
    <PackageReference Include="OdooRpc.CoreCLR.Client.V8.Models" Version="8.0.4" />
</ItemGroup>
```

#### 2. Creating a Child Class
The custom class ProductProductCustom extends the ProductProduct class. Here’s a breakdown of its components:
```
using OdooRpc.CoreCLR.Client.V8.Models;
using OdooRpc.CoreCLR.Client.V8.Models.Items;
using System.Text.Json.Serialization;

namespace ConsoleApp1Test.Specs.Models;

public class ProductProductCustom : ProductProduct
{

    [JsonIgnore]
    public Many2OneItem create_u => new Many2OneItem(this.create_uid);

    [JsonIgnore]
    public Many2OneItem write_u => new Many2OneItem(this.write_uid);

    [JsonIgnore]
    public Many2OneItem categ => new Many2OneItem(this.categ_id);

}
```

#### 3. Making Requests with the Custom Model
The following code, demonstrates how to make an asynchronous request to fetch products using the custom model:
```
// Fetch products using the custom model
public async Task<ProductProductCustom[]> FetchProductsAsync()
{
    OdooConnectionInfo odooConnectionInfo = new OdooConnectionInfo { Database = "YOUR_DB_NAME", Host = "YOUR_HOST", Port = 443, IsSSL = true, Username = "YOUR_USERNAME", Password = "YOUR_PASSWORD" };
    OdooRpcClient client = new OdooRpcClient(odooConnectionInfo);

    ProductProductCustom[] products = await client.Get<ProductProductCustom[]>(
              new OdooSearchParameters(ModelNames.ProductProduct, new OdooDomainFilter()));
    return products;
}
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- RELEASE NOTES -->
## Release Notes

* No extra library dependencies
* Newtonsoft.Json library dependency has been removed.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Any contributions you make are **greatly appreciated**.
* If you have suggestions for adding or removing projects, feel free to [open an issue](https://github.com/akifmt/OdooRpc.CoreCLR.Client.V8/issues/new) to discuss it.
* Please make sure you check your spelling and grammar.
* Create individual PR for each suggestion.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact

Project Link: [https://github.com/akifmt/OdooRpc.CoreCLR.Client.V8](https://github.com/akifmt/OdooRpc.CoreCLR.Client.V8)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* ![Dotnet](https://img.shields.io/badge/-.NET%208.0-blueviolet?logo=dotnet)
* Fork from [https://github.com/vmlf01/OdooRpc.CoreCLR.Client](https://github.com/vmlf01/OdooRpc.CoreCLR.Client)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

