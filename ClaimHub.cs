using Microsoft.AspNetCore.SignalR;

namespace ContractMonthlyClaimSystem.Hubs
{
    public class ClaimHub : Hub
    {
        // Methods for updating clients in real-time
        public async Task NotifyClaimStatusChanged(int claimId, string status)
        {
            await Clients.All.SendAsync("ClaimStatusChanged", claimId, status);
        }
    }
}
