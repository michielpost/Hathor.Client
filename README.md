# Hathor.Client

C# / .NET Client for [Hathor](https://hathor.network) Wallet API

## Install
Install the latest version from [NuGet](https://www.nuget.org/packages/Hathor/)  
NuGet package name: `Hathor`

## Getting Started

Make sure you have access to the [Hathor Headless Wallet API](https://github.com/HathorNetwork/hathor-wallet-headless). You can use the [hathornetwork/hathor-wallet-headless](https://hub.docker.com/r/hathornetwork/hathor-wallet-headless) docker image.

Start docker image:
```ps
docker pull hathornetwork/hathor-wallet-headless
docker run -p 8000:8000 hathornetwork/hathor-wallet-headless --seed_default "YOUR 24 SEED WORDS"

#Example, do not use:
docker run -p 8000:8000 hathornetwork/hathor-wallet-headless --seed_default "work above economy captain advance bread logic paddle copper change maze tongue salon sadness cannon fish debris need make purpose usage worth vault shrug"

#Example for testnet, do not use:
docker run -p 8000:8000 hathornetwork/hathor-wallet-headless --network "testnet" --server "https://node1.testnet.hathor.network/v1a/" --seed_default "work above economy captain advance bread logic paddle copper change maze tongue salon sadness cannon fish debris need make purpose usage worth vault shrug"

#Example with API key, do not use:
docker run -p 8000:8000 hathornetwork/hathor-wallet-headless --api_key "MYSECRETKEY" --seed_default "work above economy captain advance bread logic paddle copper change maze tongue salon sadness cannon fish debris need make purpose usage worth vault shrug"
```
The Hathor Headless Wallet API is now available on `http://localhost:8000`

## Sample App
There are two sample apps in this repository.

First, install Microsoft .Net 7 SDK from https://dot.net, then run the following commands:
```ps
dotnet restore
dotnet build
```

Start the included `Hathor.Client.Sample.ConsoleApp` sample app to get a quick demo of what's possible with this library.
```ps
dotnet run --project Hathor.Client.Sample.ConsoleApp
```

Start the included `Hathor.Client.Sample.WebApp` sample website get a visual look at the data.
```ps
dotnet run --project Hathor.Client.Sample.WebApp
```

## Use the Hathor Client

Create a new Hathor Client
```cs
string walletId = "my-wallet";
IHathorWalletApi client = HathorClient.GetWalletClient("http://localhost:8000", walletId, "optional-api-key");
```

Start the wallet
```cs
//"default" refers to the seed key you used when starting the docker image
var req = new StartRequest(walletId, "default");
var response = await client.Start(req);
```

When the wallet is started, you can view transaction history, create new transactions etc
```cs
//Get balance
var balance = await client.GetBalance();

//Tx history
var txHistory = await client.GetTxHistory();

//Create a transaction
var transaction = new SendTransactionSimpleRequest("ADDRESS", 1);
var response = await client.SendTransaction(transaction);
```

Check the sample apps and unit tests for more example usage.

Stop the wallet:
```cs
var response = await client.Stop();
```

### Multi Sig
View the [MULTISIG.md](MULTISIG.md) documentation to use the Multi Sig APIs from the Headless Wallet.

### Atomic Swap
View the [ATOMICSWAP.md](ATOMICSWAP.md) documentation to use the Atomic Swap APIs from the Headless Wallet.

## Full node support
There is partial support to use the [Hathor full node API](https://docs.hathor.network/#)

```cs
IHathorNodeApi nodeClient = HathorClient.GetNodeClient("https://node2.mainnet.hathor.network/v1a/");

//Get node version info
var versionInfo =  await nodeClient.GetVersion();

//Get balance of an address
var balanceInfo = await nodeClient.GetBalanceForAddress("ANY HATHOR ADDRESS")

```

## Open source credits
[RestEase](https://github.com/canton7/RestEase)

## Acknowledgements
Development has been made possible with a grant from [Hathor](https://hathor.network).
