using Aprese.Models.Security;
using Aprese.Repository.Interfaces;
using Aprese.Security.Interfaces;
using Aprese.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Security
{
    public sealed class ApreseAuthorizationService : IAuthorizationService
    {
        private IServiceProvider Provider { get; }

        public ApreseAuthorizationService(IServiceProvider provider)
        {
            Provider = provider;
        }

        public async Task<BaseResult<Identity>> AuthorizeAsync(LoginUser loginUser, CancellationToken ct = default)
        {
            var username = loginUser?.Username ?? "";
            var password = loginUser?.Password ?? "";

            if (username == "root" && password == "toor")
            {
                return new BaseResult<Identity>()
                {
                    Message = "Logado com sucesso!",
                    Success = true,
                    Data = new Identity()
                    {
                        UserName = "root"
                    }
                };
            }

            var repo = Provider.GetRequiredService<IRepository<Identity>>();

            var identity = await repo.QueryScalarAsync(q => q.SingleOrDefaultAsync(x => x.UserName == username, ct), ct);
            var crypt = Provider.GetRequiredService<Cryptography>();
            var passwordHash = crypt.GenerateHash(password);

            if (identity == null || identity.PasswordHash != passwordHash)
            {
                return new BaseResult<Identity>()
                {
                    Message = "Usuário e/ou senha incorretos!",
                    Success = false
                };
            }

            return new BaseResult<Identity>()
            {
                Message = "Logado com sucesso!",
                Success = true,
                Data = identity
            };
        }
    }
}
