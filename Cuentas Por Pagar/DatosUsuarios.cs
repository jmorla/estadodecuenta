using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuentas_Por_Pagar
{
    class DatosUsuarios
    {
        public static List<USUARIOS> MOSTRAR()
        {

            /*USAMOS LINQ. PARA BUSCAR UN USUARIO POR EL NOMBRE EMPEZANDO CON CUALQUIER LETRA*/

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var INFO = (from U in BD.USUARIOS

                            select U).ToList();

                return INFO;

            }

        }

        public static List<USUARIOS> BUSCARPORUSUARIO(string usuario)
        {

            /*USAMOS LINQ. PARA BUSCAR UN USUARIO POR EL NOMBRE

            EMPEZANDO CON CUALQUIER LETRA*/

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {
                var INFO = (from U in BD.USUARIOS

                            where U.USUARIO.StartsWith(usuario)

                            select U).ToList();

                return INFO;

            }



        }

        public static List<USUARIOS> BUSCARPORCLAVE(string clave)

        {

        /*USAMOS LINQ. PARA BUSCAR UN USUARIO POR EL NOMBRE EMPEZANDO CON CUALQUIER LETRA*/

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var INFO = (from U in BD.USUARIOS

                where U.CLAVE.StartsWith(clave)

                select U).ToList();

                return INFO;

            }

        }

    }
}
