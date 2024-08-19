using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DependencyInjection.Options
{
    public record JWTTokenAuthentication
    {
        public string? ValidAudience { get; init; }
        public string? ValidIssuer { get; init; }
        [Required, MinLength(20)] public string Secret { get; init; } = null!;
    }
}
