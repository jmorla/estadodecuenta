using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuentas_Por_Pagar
{
    class DatosProveedores
    {
        public static List<PROVEEDORES> MOSTRARDATOS()
        {
            //ESTA ES UNA INSTANCIA DE NUESTRO MODELO DE LA BASE DE DATOS

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var INFO = (from P in BD.PROVEEDORES

                            select P).ToList();

                return INFO;

            }

        }

        public static List<PROVEEDORES> BUSCARPORCODIGO(string codigo)

        {
            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())

            {

                /*USAMOS LINQ. PARA BUSCAR UN PROVEEDOR POR LA DIRECCIÓN

                EMPEZANDO CON CUALQUIER LETRA*/

                var INFO = (from P in BD.PROVEEDORES

                where P.CODIGO.StartsWith(codigo)

                select P).ToList();

                /*StartsWith HACE QUE VAYA MOSTRANDO LOS PROVEEDORES QUE    EMPIEZEN CON LAS LETRAS QUE VAMOS ESCRIBIENDO*/
            
                return INFO;

            }

        }

        public static List<PROVEEDORES> BUSCARNOMBRES(string nombres)
        {

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var INFO = (from P in BD.PROVEEDORES

                            where P.NOMBRES.StartsWith(nombres)

                            select P).ToList();

                return INFO;

            }

        }

        public static List<PROVEEDORES> BUSCARPORAPELLIDOS(string apellidos)
        {

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var INFO = (from P in BD.PROVEEDORES

                            where P.APELLIDOS.StartsWith(apellidos)

                            select P).ToList();

                return INFO;

            }

        }

        public static List<PROVEEDORES> BUSCARPORDIRECCION(string direccion)
        {

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var INFO = (from P in BD.PROVEEDORES

                            where P.DIRECCION.StartsWith(direccion)

                            select P).ToList();

                return INFO;

            }

        }

        public static List<PROVEEDORES> BUSCARPORCIUDAD(string ciudad)
        {

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var INFO = (from P in BD.PROVEEDORES

                            where P.CIUDAD.StartsWith(ciudad)

                            select P).ToList();

                return INFO;

            }

        }

        //EL SIGUIENTE MÉTODO AÑADE UN NUEVO REGISTRO

        public static void INSERTARPROVEEDOR
        (string codigo, string nombres, string apellidos, string direccion, string ciudad, string telefono)
        {
            codigo = generateId();
            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                /*PARA INSERTAR UN  NUEVO OBJETO O PROVEEDOR ASIGNANDO LOS VALORES DE LOS PARÁMETROS A LOS CAMPOS DE LA TABLA.*/

                BD.PROVEEDORES.Add(new PROVEEDORES

                {

                    CODIGO = codigo,

                    NOMBRES = nombres,

                    APELLIDOS = apellidos,

                    DIRECCION = direccion,

                    CIUDAD = ciudad

                });

                
                BD.SaveChanges();

            }

        }

        //EL SIGUIENTE MÉTODO MODIFICA UN NUEVO REGISTRO

        public static void MODIFICARPEOVEEDOR

        (string codigo, string nombres, string apellidos, string direccion, string ciudad, string telefono

        )
        {

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var MODIFICAR = (from P in BD.PROVEEDORES where P.CODIGO == codigo select P).Single();

                MODIFICAR.CODIGO = codigo;

                MODIFICAR.NOMBRES = nombres;

                MODIFICAR.APELLIDOS = apellidos;

                MODIFICAR.DIRECCION = direccion;

                MODIFICAR.CIUDAD = ciudad;

                BD.SaveChanges();

            }

        }

        public static void ELIMINARPROVEEDOR(string codigo)
        {

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var ELIMINA = (from P in BD.PROVEEDORES

                               where P.CODIGO == codigo

                               select P).Single();

                BD.PROVEEDORES.Remove(ELIMINA);

                BD.SaveChanges();

            }

        }

        public static PROVEEDORES CARGAR(string codigo)
        {

            PROVEEDORES proveedores = new PROVEEDORES();

            using (SCXPJORGEEntities BD = new SCXPJORGEEntities())
            {

                var INFO = (from P in BD.PROVEEDORES

                            where P.CODIGO == codigo

                            select P).Single();

                proveedores.CODIGO = INFO.CODIGO;

                proveedores.NOMBRES = INFO.NOMBRES;

                proveedores.APELLIDOS = INFO.APELLIDOS;

                proveedores.DIRECCION = INFO.DIRECCION; proveedores.CIUDAD = INFO.CIUDAD;

                proveedores.TELEFONO = INFO.TELEFONO;

                return proveedores;

            }

        }

        private static String generateId() {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
