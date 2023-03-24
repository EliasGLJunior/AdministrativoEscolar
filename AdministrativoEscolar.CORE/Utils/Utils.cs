using AdministrativoEscolar.CORE.DTOs.Response.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;
using MimeKit;
using AdministrativoEscolar.CORE.DTOs.Request.Email;

namespace AdministrativoEscolar.CORE.Utils
{
    public static class Util
    {
        public static string CryptoSha512(string senha)
        {
            UnicodeEncoding UE = new UnicodeEncoding();

            byte[] HashValue, MessageBytes = ASCIIEncoding.UTF8.GetBytes(senha);

            SHA512Managed shaManaged = new SHA512Managed();

            HashValue = shaManaged.ComputeHash(MessageBytes);

            string strSha = string.Join("", HashValue.Select(x => string.Format("{0:x2}", x)));

            return strSha;
        }

        public static TokenResponseDTO GeneratedTokenJwt(LoginResponseDTO loginDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key_key = Encoding.ASCII.GetBytes("{4325D943-2E58-4017-8DD5-C27599D58615}");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new[]
                    {
                        new Claim("idUsuario", loginDTO.IdUsuario.ToString()),
                        new Claim("cdTipoUsuario", loginDTO.CdTipoUsuario),
                        new Claim("txTipoUsuario", loginDTO.TxTipoUsuario),
                        new Claim("idEscola", loginDTO.IdEscola.ToString()),
                        new Claim("idAluno", loginDTO.IdAluno.ToString()),
                        new Claim("nmAluno", loginDTO.NmAluno),
                        new Claim("sbnmAluno", loginDTO.SbnmAluno)
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key_key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var response = new TokenResponseDTO
            { Token = tokenString };

            return response;
        }

        public static async Task<string> MountEmail(SendEmailRequestDTO email)
        {
            var listDestination = new List<InternetAddress>();

            foreach (var emails in email.DestinationEmail)
            {
                var newDestiny = new MailboxAddress(Encoding.UTF8, emails.Name, emails.Email);

                listDestination.Add(newDestiny);
            }

            var mailSubject = email.Subject;

            var mailMultipart = new Multipart("mixed");

            var mailBody = new TextPart("html")
            {
                Text = $@"{email.Body}"
            };

            mailMultipart.Add(mailBody);

            if (email.Archives != null && email.Archives.Count > 0)
            {
                foreach (var archive in email.Archives)
                {
                    var typeMailAttachment = archive.Type.Split("/");

                    using (var stream = new MemoryStream())
                    {

                    };

                    var mailAttachment = new MimePart(typeMailAttachment[0], typeMailAttachment[1])
                    {
                        Content = new MimeContent(GenerateStreamFromString(archive.Data), ContentEncoding.Default),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = archive.Name
                    };

                    mailMultipart.Add(mailAttachment);
                }
            }

            var message = new MimeMessage(new List<InternetAddress>(), listDestination, mailSubject, mailMultipart);

            if (email.CC != null && email.CC.Any())
            {
                var comCopiaList = new List<MailboxAddress>();
                foreach (var cc in email.CC)
                {
                    var newCC = new MailboxAddress(Encoding.UTF8, "Prezado(a)", cc);

                    comCopiaList.Add(newCC);
                }

                message.Cc.AddRange(comCopiaList);
            }

            using (var stream = new MemoryStream())
            {
                await message.WriteToAsync(stream);
                var serializedMessage = Encoding.UTF8.GetString(stream.ToArray());

                return serializedMessage;
            };
        }

        public static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
