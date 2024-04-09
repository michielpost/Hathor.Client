using Hathor.Models.Requests;
using Hathor.Models.Responses;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor
{
    public interface IHathorWalletApi
    {
        [Header("X-API-Key")]
        string? ApiKey { get; set; }

        [Header("x-wallet-id")]
        string WalletId { get; set; }

        [Post("start")]
        Task<DefaultResponse> Start([Body]StartRequest startRequest);

        [Get("health")]
        Task<HealthResponse> GetHealth([Query]string? wallet_ids = null, [Query] bool? include_fullnode = null, [Query] bool? include_tx_mining = null);

        [Post("wallet/stop")]
        Task<DefaultResponse> Stop();

        [Get("wallet/status")]
        Task<StatusResponse> GetStatus();

        [Get("wallet/balance")]
        Task<BalanceResponse> GetBalance([Query]string? token = null);

        /// <summary>
        /// Return the current address
        /// </summary>
        /// <param name="MarkAsUsed">Mark the current address as used. So, it will return a new address in the next call.</param>
        /// <returns></returns>
        [Get("wallet/address")]
        Task<AddressResponse> GetAddress([Query("mark_as_used", QuerySerializationMethod.Serialized)] bool? MarkAsUsed = null);

        /// <summary>
        /// Return the current address
        /// </summary>
        /// <param name="index">Get the address in this specific derivation path index.</param>
        /// <returns></returns>
        [Get("wallet/address")]
        Task<AddressResponse> GetAddress([Query] int index);

        /// <summary>
        /// Get information of a given address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="token">Filter the information to a custom token or HTR (default: HTR)</param>
        /// <returns></returns>
        [Get("wallet/address-info")]
        Task<AddressInfoResponse> GetAddressInfo([Query] string address, [Query] string? token = null);

        [Get("wallet/address-index")]
        Task<AddressIndexResponse> GetAddressIndex([Query] string address);

        [Get("wallet/addresses")]
        Task<AddressesResponse> GetAddresses();


        /// <summary>
        /// /wallet/tx-history
        /// </summary>
        /// <returns></returns>
        [Get("wallet/tx-history")]
        Task<TxHistoryResponse> GetTxHistory([Query]int? limit = null);

        [Get("wallet/transaction")]
        Task<Transaction> GetTransaction([Query]string id);

        [Post("wallet/simple-send-tx")]
        Task<SendTransactionResponse> SendTransaction([Body] SendTransactionSimpleRequest sendTransactionRequest);

        [Post("wallet/send-tx")]
        Task<SendTransactionResponse> SendTransaction([Body] SendTransactionRequest sendTransactionRequest);

        [Get("wallet/utxo-filter")]
        Task<UtxoFilterResponse> UtxoFilter([Query] int? max_utxos = 255, 
            [Query] string? token = null, 
            [Query(Name = "filter_address")] string? filterAddress = null, 
            [Query(Name = "amount_smaller_than")] int? amountSmallerThan = null,
            [Query(Name = "amount_bigger_than")] int? amountBiggerThan = null,
            [Query(Name = "maximum_amount")] int? maximumAmount = null,
            [Query(Name = "only_available_utxos")] bool? onlyAvailableUtxos = false
            );

        [Post("wallet/utxo-consolidation")]
        Task<UtxoConsolidationResponse> UtxoConsolidation([Body] UtxoConsolidationRequest utxoConsolidationRequest);


        #region Custom Tokens

        [Post("wallet/create-token")]
        Task<CreateTokenResponse> CreateToken([Body] CreateTokenRequest creatTokenRequest);

        [Get("configuration-string")]
        Task<ConfigurationStringResponse> GetConfigurationString([Query] string token);

        [Post("wallet/mint-tokens")]
        Task<DefaultTokenResponse> MintTokens([Body] MintTokensRequest mintTokensRequest);

        [Post("wallet/melt-tokens")]
        Task<DefaultTokenResponse> MeltTokens([Body] MeltTokensRequest meltTokensRequest);

        #endregion

        [Post("wallet/create-nft")]
        Task<DefaultTokenResponse> CreateNft([Body] CreateNftRequest createNftRequest);

        [Get("wallet/tx-confirmation-blocks")]
        Task<TxConfirmationBlocksResponse> GetTxConfirmationBlocks([Query(Name ="id")] string txId);

        [Post("wallet/decode")]
        Task<DecodeResponse> Decode([Body] DecodeRequest decodeRequest);


        [Post("multisig-pubkey")]
        Task<GetMultiSigPubKeyResponse> MultiSigGetPubKey([Body] GetMultiSigPubKeyRequest getMultiSigPubKeyRequest);

        [Post("wallet/p2sh/tx-proposal")]
        Task<MultiSigSendTransactionProposalResponse> MultiSigSendTransactionProposal([Body] SendTransactionRequest sendTransactionRequest);

        [Post("wallet/p2sh/tx-proposal/get-my-signatures")]
        Task<SignaturesResponse> MultiSigGetMySignaturesForTxProposal([Body] EncodedTxRequest encodedTxRequest);

        [Post("wallet/p2sh/tx-proposal/sign")]
        Task<SignaturesResponse> MultiSigSignTxProposal([Body] EncodedTxWithSignaturesRequest encodedTxWithSignaturesRequest);

        [Post("wallet/p2sh/tx-proposal/sign-and-push")]
        Task<SendTransactionResponse> MultiSigSignAndPush([Body] EncodedTxWithSignaturesRequest encodedTxWithSignaturesRequest);


        [Post("wallet/atomic-swap/tx-proposal")]
        Task<AtomicSwapTxProposalResponse> AtomicSwapCreateTxProposal([Body] AtomicSwapPartialTransactionRequest partialTransactionRequest);

        [Post("wallet/atomic-swap/tx-proposal/get-my-signatures")]
        Task<AtomicSwapTxProposalGetSignaturesResponse> AtomicSwapGetSignaturesForTxProposal([Body] AtomicSwapPartialTxRequest atomicSwapPartialTxRequest);

        [Post("wallet/atomic-swap/tx-proposal/sign")]
        Task<AtomicSwapSignTxProposalResponse> AtomicSwapSignTxProposal([Body] AtomicSwapSignRequest atomicSwapSignRequest);

        [Post("wallet/atomic-swap/tx-proposal/sign-and-push")]
        Task<DefaultTokenResponse> AtomicSwapSignAndPush([Body] AtomicSwapSignRequest atomicSwapSignRequest);

        [Post("wallet/atomic-swap/tx-proposal/unlock")]
        Task<DefaultResponse> AtomicSwapUnlock([Body] AtomicSwapPartialTxRequest partialTxRequest);

        [Get("wallet/atomic-swap/tx-proposal/get-locked-utxos")]
        Task<AtomicSwapGetLockedUtxosResponse> AtomicSwapGetLockedUtxos();

        [Post("wallet/atomic-swap/tx-proposal/get-input-data")]
        Task<AtomicSwapTxProposalGetSignaturesResponse> AtomicSwapGetInputData([Body] AtomicSwapGetInputDataRequest getInputDataRequest);

    }
}
