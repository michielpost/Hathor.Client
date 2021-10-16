using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{
    public class Server
    {
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        [JsonProperty("app_version")]
        public string? AppVersion { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("network")]
        public string? Network { get; set; }

        [JsonProperty("uptime")]
        public double? Uptime { get; set; }

        [JsonProperty("entrypoints")]
        public List<string> Entrypoints { get; set; } = new();
    }

    public class KnownPeer
    {
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        [JsonProperty("entrypoints")]
        public List<string> Entrypoints { get; set; } = new();
    }

    public class NodeSyncTimestamp
    {
        [JsonProperty("latest_timestamp")]
        public int? LatestTimestamp { get; set; }

        [JsonProperty("synced_timestamp")]
        public int? SyncedTimestamp { get; set; }
    }

    public class Plugins
    {
        [JsonProperty("node-sync-timestamp")]
        public NodeSyncTimestamp NodeSyncTimestamp { get; set; } = new();
    }

    public class ConnectedPeer : Server
    {
        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("last_message")]
        public double LastMessage { get; set; }

        [JsonProperty("plugins")]
        public Plugins? Plugins { get; set; }

        [JsonProperty("warning_flags")]
        public List<string> WarningFlags { get; set; } = new();

        [JsonProperty("protocol_version")]
        public string? ProtocolVersion { get; set; }
    }

    public class ConnectingPeer
    {
        [JsonProperty("deferred")]
        public string? Deferred { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }
    }

    public class Connections
    {
        [JsonProperty("connected_peers")]
        public List<ConnectedPeer> ConnectedPeers { get; set; } = new();

        [JsonProperty("connecting_peers")]
        public List<ConnectingPeer> ConnectingPeers { get; set; } = new();
    }

    public class Dag
    {
        [JsonProperty("first_timestamp")]
        public int? FirstTimestamp { get; set; }

        [JsonProperty("latest_timestamp")]
        public int? LatestTimestamp { get; set; }
    }

    public class StatusResponse
    {
        [JsonProperty("server")]
        public Server Server { get; set; } = new();

        [JsonProperty("peers_whitelist")]
        public List<string> PeersWhitelist { get; set; } = new();

        [JsonProperty("known_peers")]
        public List<KnownPeer> KnownPeers { get; set; } = new();

        [JsonProperty("connections")]
        public Connections Connections { get; set; } = new();

        [JsonProperty("dag")]
        public Dag Dag { get; set; } = new();
    }

}
