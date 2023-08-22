using Paytech.Models;
using Paytech.Repositories;

namespace Paytech.Services
{
    public class LoginService
    {
        private ILoginRepository _loginRepository;

        public LoginService()
        {
            _loginRepository = new LoginRepository();
        }

        public bool Insert(Login login)
        {
            return _loginRepository.Insert(login);
        }
        public List<Login> GetAll()
        {
            return _loginRepository.GetAll();
        }

        public async Task<bool> AuthenticateAsync(string username, string senha)
        {
            Login login = _loginRepository.GetByUsername(username);

            if (login != null && IsValidPassword(login, senha))
            {
                return true;
            }
            return false;
        }

        private bool IsValidPassword(Login login, string password)
        {
            return login.Senha == password;
        }
    }
}
