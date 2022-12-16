# Multi Sig usage

Make sure to setup Multi Sig wallets following the Hathor Documentation:
- https://hathor.gitbook.io/hathor/guides/multisig-wallet/sending-transactions
- https://github.com/HathorNetwork/hathor-wallet-headless/blob/master/MULTISIG.md


Example usage can be found in [HathorMultiSigTests.cs](Hathor.Tests/HathorMultiSigTests.cs)


## Collect Public Keys

```cs
IHathorWalletApi client = HathorClient.GetWalletClient("http://localhost:8000", "WALLET_SEED_KEY");

var xpubkey = await client. MultiSigGetPubKey(new GetMultiSigPubKeyRequest("WALLET_SEED_KEY"));
            
```

## Start MultiSig Wallets
It's the same as starting a normal wallet, only set `multiSig` to `true`

```cs
var multi1Response = await client.Start(new StartRequest("WALLET_ID", "WALLET_SEED_KEY", multiSig: true));
```

## Create a MultiSig Transaction
You can create a normal transaction, but instead of sending it, you create a proposal. This will return a transaction Hex.

```cs
SendTransactionRequest transaction = new SendTransactionRequest()
{
    Outputs = new System.Collections.Generic.List<Output>()
    {
        new Output("HTR_ADDRESS", 1, "00")
    }
};

var response = await client. MultiSigSendTransactionProposal(transaction);

var txHex = response.TxHex;
```

## Check the MultiSig Transaction
The proposal hex can be checked before signing it.
```cs
var decoded = await client.Decode(new DecodeRequest() { TxHex = txHex});
```

## Get Participant Signatures
When you trust the hex you received, you can sign it.
```cs
var signature = await clientMultiSig1. MultiSigGetMySignaturesForTxProposal(new EncodedTxRequest(txHex));
```

## Send the MultiSig Transaction
When you collected enough signatures from the MultiSig participants, you can push the transaction to the network.
```cs
var response = await clientMultiSig1. MultiSigSignAndPush(new EncodedTxWithSignaturesRequest(txHex, new System.Collections.Generic.List<string>() { signature1, signature2 }));
```
