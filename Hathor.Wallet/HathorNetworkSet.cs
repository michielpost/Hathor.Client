using NBitcoin;
using NBitcoin.DataEncoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NBitcoin.Altcoins.Bitcore;

namespace Hathor.Wallet
{
    internal class HathorNetworkSet : NetworkSetBase
    {
        public static HathorNetworkSet Instance { get; } = new HathorNetworkSet();
        public override string CryptoCode => "HTR";

        static Tuple<byte[], int>[] pnSeed6_main = {
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0x33,0x0f,0xde,0xe0}, 8555),
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0x25,0x78,0xbe,0x4c}, 8555),
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0x25,0x78,0xba,0x55}, 8555),
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0xb9,0xca,0x8c,0x3c}, 8555),
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0xbc,0x47,0xdf,0xce}, 8555),
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0xb9,0xc2,0x8e,0x7a}, 8555),
        };

        static Tuple<byte[], int>[] pnSeed6_test = {
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0x58,0x44,0x34,0xac}, 8666),
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0x25,0x78,0xba,0x55}, 8666),
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0xbc,0x47,0xdf,0xce}, 8666),
            Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0xb9,0xc2,0x8e,0x7a}, 8666),
        };

        protected override NetworkBuilder CreateMainnet()
        {
            NetworkBuilder builder = new NetworkBuilder();
            builder.SetConsensus(new Consensus()
            {
                SubsidyHalvingInterval = 210000,
                MajorityEnforceBlockUpgrade = 750,
                MajorityRejectBlockOutdated = 950,
                MajorityWindow = 1000,
                BIP34Hash = new uint256("604148281e5c4b7f2487e5d03cd60d8e6f69411d613f6448034508cea52e9574"),
                PowLimit = new Target(new uint256("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                PowTargetTimespan = TimeSpan.FromSeconds(3.5 * 24 * 60 * 60),
                PowTargetSpacing = TimeSpan.FromSeconds(2.5 * 60),
                PowAllowMinDifficultyBlocks = false,
                PowNoRetargeting = false,
                RuleChangeActivationThreshold = 250,
                MinerConfirmationWindow = 1000,
                CoinbaseMaturity = 100,
                ConsensusFactory = BitcoreConsensusFactory.Instance,
                SupportSegwit = false
            })
                .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("ht"))
                .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("ht"))
            .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] { 0x28 })
            .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] { 0x64 })
            .SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 0x80 })
            .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] { 0x04, 0x88, 0xb2, 0x1e })
            .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] { 0x03, 0x52, 0x3b, 0x05 })
            .SetMagic(0xf9beb4d9)
            .SetPort(8333)
            .SetRPCPort(19332)
            .SetMaxP2PVersion(80009)
            .AddSeeds(ToSeed(pnSeed6_main))
             .SetGenesis("010000000000000000000000000000000000000000000000000000000000000000000000c787795041016d5ee652e55e3a6aeff6c8019cf0c525887337e0b4206552691613f7fc58f0ff0f1ea12400000101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff4004ffff001d010438506f77657264652062792042697473656e642d4575726f7065636f696e2d4469616d6f6e642d4d41432d42332032332f4170722f32303137ffffffff010000000000000000434104678afdb0fe5548271967f1a67130b7105cd6a828e03909a67962e0ea1f61deb649f6bc3f4cef38c4f35504e51ec112de5c384df7ba0b8d578a4c702b6bf11d5fac00000000")
            .SetName("htr-mainnet");

            return builder;
        }

        protected override NetworkBuilder CreateTestnet()
        {
            NetworkBuilder builder = new NetworkBuilder();
            builder.SetConsensus(new Consensus()
            {
                SubsidyHalvingInterval = 210000,
                MajorityEnforceBlockUpgrade = 750,
                MajorityRejectBlockOutdated = 950,
                MajorityWindow = 1000,
                BIP34Hash = new uint256("604148281e5c4b7f2487e5d03cd60d8e6f69411d613f6448034508cea52e9574"),
                PowLimit = new Target(new uint256("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                PowTargetTimespan = TimeSpan.FromSeconds(3.5 * 24 * 60 * 60),
                PowTargetSpacing = TimeSpan.FromSeconds(2.5 * 60),
                PowAllowMinDifficultyBlocks = false,
                PowNoRetargeting = false,
                RuleChangeActivationThreshold = 250,
                MinerConfirmationWindow = 1000,
                CoinbaseMaturity = 100,
                ConsensusFactory = BitcoreConsensusFactory.Instance,
                SupportSegwit = false,
            })
            .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("tn"))
            .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("tn"))
            .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] { 0x49 })
            .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] { 0x87 })
            .SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 0x80 })
            .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] { 0x04, 0x34, 0xc8, 0xc4 })
            .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] { 0x01, 0x88, 0xb2, 0x1e })
            .SetMagic(0xf9beb4d0)
            .SetPort(8333)
            .SetRPCPort(19332)
            .SetMaxP2PVersion(80009)
            .AddSeeds(ToSeed(pnSeed6_test))
            .SetGenesis("00")
            .SetName("htr-testnet");

            return builder;
        }

        protected override NetworkBuilder CreateRegtest()
        {
            NetworkBuilder builder = CreateMainnet();

            builder
            .SetName("htr-regnet")
            .AddAlias("regnet");

            return builder;
        }
    }
}
