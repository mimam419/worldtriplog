
using System.Diagnostics;

namespace TheWorld.Services {
    public class DebugMailService : IMailService {
        public void SendMail(string to, string from, string subject, string body) {
            Debug.WriteLine($"Sending Mail:\nTo: {to}\nFrom: {from}\nSubject: {subject}\nBody: {body}\n\n");
        }
    }
}