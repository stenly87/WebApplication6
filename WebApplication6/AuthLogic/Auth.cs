using System.Text;

namespace WebApplication6.AuthLogic
{
    public class AuthLogic
    {
        internal static void UpdateSession(user01Context _context, Session session)
        {
            session.SessionKey = GenerateSessionKey();
            session.Start = DateTime.UtcNow;
            session.Expiration = DateTime.UtcNow.AddHours(2);
            _context.Sessions.Update(session);
            _context.SaveChanges();
        }

        internal static void AddSession(user01Context _context, User user)
        {
            _context.Sessions.Add(new Session
            {
                IdUser = user.Id,
                Start = DateTime.UtcNow,
                Expiration = DateTime.UtcNow.AddHours(2),
                SessionKey = GenerateSessionKey()
            });
            _context.SaveChanges();
        }

        static string GenerateSessionKey()
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
                sb.Append((char)rnd.Next(0, 64000));
            return sb.ToString();
        }
    }
}
