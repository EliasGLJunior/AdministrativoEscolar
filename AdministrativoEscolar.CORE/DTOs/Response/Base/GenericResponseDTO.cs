using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Response.Base
{
    public class GenericResponseDTO<T> : ResponseDTO
    {
        public GenericResponseDTO() { }

        public GenericResponseDTO(T data, string erro)
        {
            if (string.IsNullOrEmpty(erro))
            {
                Data = data;
                Sucesso = true;
            }
            else
            {
                Data = data;
                Sucesso = false;
                Detalhe = erro;
            }
        }

        public GenericResponseDTO(T data)
        {
            Data = data;
            Sucesso = true;
        }
        public T Data { get; set; }
    }
}
