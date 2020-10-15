using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models.RequestModels
{
    public class NewsPostRequest
    {
        public string TokenId { get; set; }
        public string Description { get; set; }
    }
}
