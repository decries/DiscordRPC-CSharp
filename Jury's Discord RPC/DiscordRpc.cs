using DiscordRPC;
using Jury_s_Discord_RPC;


namespace Kratos
{
    internal class DiscordRPC
    {
        public static DiscordRpcClient client;

        public static void Initialize()
        {
            
            client = new DiscordRpcClient("799394996380893195");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Best Booter for the price.",
                State = ".gg/8SRS2eHEdp",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "kratoslogo",
                    LargeImageText = ".gg/8SRS2eHEdp",
                }
            });
        }
    }
}