using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ContratoMantenimientoEntities1  db = new ContratoMantenimientoEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        DataView ImportarDatosSites(string filename)
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties= 'Excel 8.0;HDR=YES'" ,filename );
            using (OleDbConnection connection = new OleDbConnection(conexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [BaseSitiosTelemetria$]", connection);
                OleDbDataAdapter adaptador = new OleDbDataAdapter { SelectCommand = command };
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable dt = ds.Tables[0];
         
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var SiteID     = dr[1];
                        var ID_AA_FB   = dr[2];
                        var Address    = dr[3];
                        var CreateDate = dr[5];
                        var Tipo       = dr[7];
                        var Measures   = dr[9];
                        var Latitud    = dr[10];
                        var Longitud   = dr[11];

                        var query = (from sm in db.SitesMtto 
                                     where sm.siteIDDatagate.ToString() == SiteID.ToString() 
                                     select sm).FirstOrDefault();

                        if (query == null)
                        {
                            SitesMtto s = new SitesMtto();

                            s.siteIDDatagate     = SiteID.ToString();
                            s.idFieldBeat        = ID_AA_FB.ToString();
                            s.addressDatagate    = Address.ToString();
                            s.createDateDatagate = Convert.ToDateTime(CreateDate);
                            s.typeDevice         = Tipo.ToString();
                            s.MeasuresDevice     = Measures.ToString();
                            if (Latitud.ToString() != "" && Longitud.ToString() != "")
                            {
                                s.latitudeSite  = Convert.ToDouble(Latitud);
                                s.longitudeSite = Convert.ToDouble(Longitud);
                            }

                             db.SitesMtto.Add(s);
                        }
                        else
                        {
                            query.siteIDDatagate     = SiteID.ToString();
                            query.idFieldBeat        = ID_AA_FB.ToString();
                            query.addressDatagate    = Address.ToString();
                            query.createDateDatagate = Convert.ToDateTime(CreateDate);
                            query.typeDevice         = Tipo.ToString();
                            query.MeasuresDevice     = Measures.ToString();
                            if (Latitud.ToString() != "" && Longitud.ToString() != "")
                            {
                                query.latitudeSite = Convert.ToDouble(Latitud);
                                query.longitudeSite = Convert.ToDouble(Longitud);
                            }
                            db.SaveChanges();
                        }

                     db.SaveChanges();
                    }

                    connection.Close();
                    return ds.Tables[0].DefaultView;
                }
            }
        }
        DataView ImportarDatosTickets(string filename)
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties= 'Excel 8.0;HDR=YES'", filename );
            using (OleDbConnection connection = new OleDbConnection(conexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Tickets as of 03-11-21$]", connection);
                OleDbDataAdapter adaptador = new OleDbDataAdapter { SelectCommand = command };
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable dt = ds.Tables[0];

                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var ticketNumber    = dr[0];
                        var createDate      = dr[1];
                        var siteIDDatagate  = dr[2];
                        var currentStatus   = dr[3];
                        var teamAssigned    = dr[4];
                        var closedDateDG    = dr[5];                       
                        var lastUpdated     = dr[6];
                        var SLAPlan         = dr[7];
                        var Overdue         = dr[8];
                        var tipoEvento      = dr[9];



                        var query = (from sm in db.Tickets
                                     where sm.ticketNumber.ToString() == ticketNumber.ToString()
                                     select sm).FirstOrDefault();


                        var queryDates = (from sm in db.Tickets
                                          where sm.ticketNumber.ToString() == ticketNumber.ToString()
                                          orderby sm.createDate
                                          select new { Ticket = sm.ticketNumber,
                                                       Creación = sm.createDate,
                                                       Actualizado = sm.lastUpdated,
                                                       Status = sm.currentStatus 
                                          });
                                          
                        if(queryDates != null)
                        {
                            foreach(var e in queryDates)
                            {
                                Console.WriteLine("-----------" +
                                    "-------------------------" +
                                    "-------------------------" +
                                    "-------------------------" +
                                    "-----");
                                Console.WriteLine(e);
                            }
                            
                        }               

                        if(query == null)
                        {
                            Tickets t = new Tickets();

                            t.ticketNumber   = Convert.ToInt32(ticketNumber);
                            t.createDate     = Convert.ToDateTime(createDate);
                            t.siteIDDatagate = siteIDDatagate.ToString();
                            t.currentStatus  = currentStatus.ToString();
                            t.teamAssigned   = teamAssigned.ToString();
                            if(t.closedDateDG is DBNull)
                            {
                                Convert.IsDBNull(t.closedDateDG = Convert.ToDateTime(closedDateDG));
                            }                          
                            t.lastUpdated = Convert.ToDateTime(lastUpdated);
                            t.SLAPlan     = SLAPlan.ToString();
                            t.Overdue     = Overdue.ToString();
                            t.tipoEvento  = tipoEvento.ToString();

                            db.Tickets.Add(t);
                        }
                        else
                        {
                            query.ticketNumber   = Convert.ToInt32(ticketNumber);
                            query.createDate     = Convert.ToDateTime(createDate);
                            query.siteIDDatagate = siteIDDatagate.ToString();
                            query.currentStatus  = currentStatus.ToString();
                            query.teamAssigned   = teamAssigned.ToString();
                            if (query.closedDateDG is DBNull)
                            {
                                query.closedDateDG = Convert.ToDateTime(closedDateDG);
                            }
                            query.lastUpdated = Convert.ToDateTime(lastUpdated);
                            query.SLAPlan     = SLAPlan.ToString();
                            query.Overdue     = Overdue.ToString();
                            query.tipoEvento  = tipoEvento.ToString();
                            db.SaveChanges();
                        }

                        db.SaveChanges();
                    }

                    connection.Close();
                    return ds.Tables[0].DefaultView;
                }
            }
        }
        DataView ImportarDatosIntrumentacion(string filename)
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties= 'Excel 8.0;HDR=YES'", filename);
            using (OleDbConnection connection = new OleDbConnection(conexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [$]", connection);
                OleDbDataAdapter adaptador = new OleDbDataAdapter { SelectCommand = command };
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable dt = ds.Tables[0];

                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var siteIDDatagate = dr[0];
                        var datetime       = dr[1];
                        var csq            = dr[2];
                        var battery        = dr[3];
                        var lastCallIn     = dr[4];

                        var query = (from sm in db.BehaviorInstrumentation
                                     where sm.siteIDDatagate.ToString() == siteIDDatagate.ToString()
                                     select sm).FirstOrDefault();

                        if (query == null)
                        {
                            BehaviorInstrumentation i = new BehaviorInstrumentation();

                            i.siteIDDatagate = Convert.ToString(siteIDDatagate);
                            i.datetime       = Convert.ToDateTime(datetime);
                            i.csq            = Convert.ToInt32(csq);
                            i.battery        = Convert.ToInt32(battery);
                            i.lastCallIn     = Convert.ToDateTime(lastCallIn);

                            db.BehaviorInstrumentation.Add(i);
                        }
                        else
                        {
                            query.siteIDDatagate = siteIDDatagate.ToString();
                            query.datetime       = Convert.ToDateTime(datetime);
                            query.csq            = Convert.ToInt32(csq);
                            query.battery        = Convert.ToInt32(battery);
                            query.lastCallIn     = Convert.ToDateTime(lastCallIn);

                            db.SaveChanges();
                        }
                    db.SaveChanges();
                    }
                    connection.Close();
                    return ds.Tables[0].DefaultView;
                }
            }
        }
        DataView ImportarDatosHidraulics(string filename)
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties= 'Excel 8.0;HDR=YES'", filename);
            using (OleDbConnection connection = new OleDbConnection(conexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [$]", connection);
                OleDbDataAdapter adaptador = new OleDbDataAdapter { SelectCommand = command };
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable dt = ds.Tables[0];

                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var siteIDDatagate = dr[0];
                        var datetime       = dr[1];
                        var ch1            = dr[2];
                        var ch2            = dr[3];
                        var ch3            = dr[4];

                        var query = (from sm in db.BehaviorHidraulic
                                     where sm.siteIDDatagate.ToString() == siteIDDatagate.ToString()
                                     select sm).FirstOrDefault();

                        if (query == null)
                        {
                            BehaviorHidraulic i = new BehaviorHidraulic();

                            i.siteIDDatagate = Convert.ToString(siteIDDatagate);
                            i.datetime       = Convert.ToDateTime(datetime);
                            i.ch1Value       = Convert.ToInt32(ch1);
                            i.ch2Value       = Convert.ToInt32(ch2);
                            i.ch3Value       = Convert.ToInt32(ch3);

                            db.BehaviorHidraulic.Add(i);
                        }
                        else
                        {
                            query.siteIDDatagate = siteIDDatagate.ToString();
                            query.datetime       = Convert.ToDateTime(datetime);
                            query.ch1Value       = Convert.ToInt32(ch1);
                            query.ch2Value       = Convert.ToInt32(ch2);
                            query.ch3Value       = Convert.ToInt32(ch3);

                            db.SaveChanges();
                        }
                        db.SaveChanges();
                    }
                    connection.Close();
                    return ds.Tables[0].DefaultView;
                }
            }     
        }
        DataView ImportarSuppliesUsed(string filename)
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties= 'Excel 8.0;HDR=YES;IMEX=1'", filename);
            using (OleDbConnection connection = new OleDbConnection(conexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Reportes$]", connection);
                OleDbDataAdapter adaptador = new OleDbDataAdapter { SelectCommand = command };
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable dt = ds.Tables[0];

                using (OleDbDataReader dr = command.ExecuteReader())
                {                   
                 
                    while (dr.Read())
                    {
                        /*codigotarea*/
                        var idTaskFieldBeat = dr[0];
                        /*sucursal*/
                        var idFieldBeat     = dr[2];
                        var TaskType        = dr[20];
                        var datetimeTask    = dr[22];
                        var currentStatus   = dr[41];
                        var suppliesUsed    = dr[55];
                        //var quantity        = dr[5];

                        var query = (from sm in db.TaskSuppliesUsed
                                     where sm.idTaskFieldbeat.ToString() == idTaskFieldBeat.ToString()
                                     select sm).FirstOrDefault();

                        var suppliesquery = (from sm in db.TaskSuppliesUsed
                                             where sm.suppliesUsed.ToString().ToLower().Contains("bateria")  ||
                                                   sm.suppliesUsed.ToString().ToLower().Contains("antena")   ||
                                                   sm.suppliesUsed.ToString().ToLower().Contains("sim")      ||
                                                   sm.suppliesUsed.ToString().ToLower().Contains("simcard")
                                             select sm).FirstOrDefault();

                        //if (suppliesquery != null)
                        //{
                        //    int bateria = 0;
                        //    int simcard = 0;
                        //    int antena = 0;
                            
                        //    foreach (var s in suppliesquery.ToString())
                        //    {
                        //        string[] insumos = suppliesquery.suppliesUsed.ToString().ToLower().Split(',');
                        //        foreach (var i in insumos)
                        //        {
                        //            switch (i)
                        //            {
                        //                case "bateria":
                        //                    bateria++;
                        //                    break;

                        //                case "sim":
                        //                case "simcard":
                        //                    simcard++;
                        //                    break;

                        //                case "antena plana":
                        //                    antena++;
                        //                    break;
                        //            }
                        //        }
                               
                        //    }

                        //    Console.WriteLine("Insumos utilizados basado en el ultimo reporte:");
                        //    Console.WriteLine("Baterias: " + bateria);
                        //    Console.WriteLine("Tarjetas SIM: " + simcard);
                        //    Console.WriteLine("Antenas: " + antena);
                        //}


                        if (query == null)
                        {
                            TaskSuppliesUsed t = new TaskSuppliesUsed();

                            t.idFieldbeat      = Convert.ToString(idFieldBeat);
                            t.idTaskFieldbeat  = idTaskFieldBeat.ToString();
                            t.datetimeTask     = Convert.ToDateTime(datetimeTask);
                            t.TaskType         = TaskType.ToString();
                            t.suppliesUsed     = suppliesUsed.ToString();
                            t.currentStatus    = currentStatus.ToString();
                            //if(t.quantity is DBNull)
                            //{
                            //   Convert.IsDBNull( t.quantity = Convert.ToInt32(quantity));
                            //}
                            if (t.currentStatus.Equals("TERMINADA"))
                            {
                                db.TaskSuppliesUsed.Add(t);
                            }
                            
                        }
                        else
                        {
                            query.idFieldbeat     = Convert.ToString(idFieldBeat);
                            query.idTaskFieldbeat = idTaskFieldBeat.ToString();
                            query.datetimeTask    = Convert.ToDateTime(datetimeTask);
                            query.TaskType        = TaskType.ToString();
                            query.suppliesUsed    = suppliesUsed.ToString();
                            query.currentStatus   = currentStatus.ToString();
                            //if(query.quantity is DBNull)
                            //{
                            //   Convert.IsDBNull( query.quantity = Convert.ToInt32(quantity));
                            //}

                            if (query.currentStatus.Equals("TERMINADA"))
                            {
                                db.SaveChanges();
                            }
                            
                        }

                        db.SaveChanges();
                    }

                    connection.Close();
                    return ds.Tables[0].DefaultView;
                }
            }
        }
        DataView ImportarServicioTecnico(string filename)
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties= 'Excel 8.0;HDR=YES'", filename);
            using (OleDbConnection connection = new OleDbConnection(conexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [$]", connection);
                OleDbDataAdapter adaptador = new OleDbDataAdapter { SelectCommand = command };
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable dt = ds.Tables[0];

                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var datetimeIn       = dr[0];
                        var datetimeOut      = dr[1];
                        var serviceReference = dr[2];
                        var suppliesUsed     = dr[3];
                        var diagnosticDevice = dr[4];
                        var idFieldBeat      = dr[5];

                        var query = (from sm in db.TechnicalServices
                                     where sm.serviceReference.ToString() == serviceReference.ToString()
                                     select sm).FirstOrDefault();

                        if (query == null)
                        {
                            TechnicalServices t = new TechnicalServices();

                            t.datetimeIn        = Convert.ToDateTime(datetimeIn);
                            t.datetimeOut       = Convert.ToDateTime(datetimeOut);
                            t.serviceReference  = serviceReference.ToString();
                            t.suppliesUsed      = suppliesUsed.ToString();
                            t.diagnosticDevice  = diagnosticDevice.ToString();
                            t.idFieldBeat       = idFieldBeat.ToString();

                            db.TechnicalServices.Add(t);
                        }
                        else
                        {
                            query.datetimeIn        = Convert.ToDateTime(datetimeIn);
                            query.datetimeOut       = Convert.ToDateTime(datetimeOut);
                            query.serviceReference  = serviceReference.ToString();
                            query.suppliesUsed      = suppliesUsed.ToString();
                            query.diagnosticDevice  = diagnosticDevice.ToString();
                            query.idFieldBeat       = idFieldBeat.ToString();

                            db.SaveChanges();
                        }

                        db.SaveChanges();
                    }
                    connection.Close();
                    return ds.Tables[0].DefaultView;
                }
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls; *.xlsx;",
                Title = "Seleccionar Archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = ImportarDatosSites(openFileDialog.FileName);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls; *.xlsx;",
                Title = "Seleccionar Archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = ImportarDatosTickets(openFileDialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls; *.xlsx;",
                Title = "Seleccionar Archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = ImportarDatosIntrumentacion(openFileDialog.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls; *.xlsx;",
                Title = "Seleccionar Archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = ImportarDatosHidraulics(openFileDialog.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls; *.xlsx;",
                Title = "Seleccionar Archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = ImportarSuppliesUsed(openFileDialog.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls; *.xlsx;",
                Title = "Seleccionar Archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = ImportarServicioTecnico(openFileDialog.FileName);
            }
        }
    }
}
