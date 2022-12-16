# Atomic Swap usage

Hathor documentation about Atomic Swap usage can be found here:
- https://hathor.gitbook.io/hathor/guides/headless-wallet/atomic-swap


Example usage can be found in [HathorAtomicSwapTests.cs](Hathor.Tests/HathorAtomicSwapTests.cs)


## Alice creates a TX proposal

```cs
var txProposalStep1Response = await clientAlice.AtomicSwapCreateTxProposal(new AtomicSwapPartialTransactionRequest()
        {
            Send = new Send
            {
                Tokens = new() { new TokenForPartialSend() { Token = aliceTokenId, Value = 1 } }
            },
            Receive = new Receive
            {
                Tokens = new() { new TokenForPartialReceive() { Token = bobTokenId, Value = 10 } }
            }
        });

var alicePartialTxHex = txProposalStep1Response.Data;
            
```

## TX proposals can be viewed / decoded

```cs
var step2Response = await clientBob.Decode(new DecodeRequest() {  PartialTx = alicePartialTxHex });
            
```

##  Step 3: Bob updates Alice's partial transaction

```cs
var txProposalStep3Response = await clientBob.AtomicSwapCreateTxProposal(new AtomicSwapPartialTransactionRequest()
{
    PartialTx = alicePartialTxHex,
    Send = new Send
    {
        Tokens = new() { new TokenForPartialSend() { Token = bobTokenId, Value = 10 } }
    },
    Receive = new Receive
    {
        Tokens = new() { new TokenForPartialReceive() { Token = aliceTokenId, Value = 1 } }
    }
});
```

## Generate signatures for TX Proposal
```cs
 var step5Response = await clientAlice.AtomicSwapGetSignaturesForTxProposal(new AtomicSwapPartialTxRequest() { PartialTx = bobPartialTxHex });

 var aliceSignature = step5Response.Signatures;
```

## Bob signs and push the transaction
```cs
 var step7Response = await clientBob.AtomicSwapSignAndPush(new AtomicSwapSignRequest()
            { 
                PartialTx= bobPartialTxHex,
                Signatures = new List<string>()
                {
                    bobSignature,
                    aliceSignature
                }
            });
```