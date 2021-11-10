using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using System.Configuration;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        readonly ContratoMantenimientoEntities1  db = new ContratoMantenimientoEntities1();
        readonly hwmdbEntities db2 = new hwmdbEntities();

        

        public Form1()
        {
            InitializeComponent();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImportarDatosIntrumentacion();
            //timer1.Interval= 60000;
            //timer1.Enabled = true;
            //timer1.Tick += new EventHandler(this.checkstatus);
        }

        public void checkstatus(object sender, EventArgs e)
        {
            var today = DateTime.Now;
            if (today.ToShortTimeString() == "15:30")
            {
                ImportarDatosIntrumentacion();
            }
         
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
                        var SiteID     = dr["SiteID"];
                        var ID_AA_FB   = dr["ID AA FB"];
                        var Address    = dr["Address"];
                        var CreateDate = dr["CreateDate"];
                        var Tipo       = dr["Tipo"];
                        var Measures   = dr["Medidas"];
                        var Latitud    = dr["Latitud"];
                        var Longitud   = dr["Longitud"];

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
                        var ticketNumber    = dr["Ticket Number"];
                        var createDate      = dr["Date Created"];
                        var siteIDDatagate  = dr["Subject"];
                        var currentStatus   = dr["Current Status"];
                        var teamAssigned    = dr["Team Assigned"];
                        var closedDateDG    = dr["Closed Date"];                       
                        var lastUpdated     = dr["Last Updated"];
                        var SLAPlan         = dr["SLA Plan"];
                        var Overdue         = dr["Overdue"];
                        var tipoEvento      = dr["Tipo de Evento"];



                        var query = (from sm in db.Tickets
                                     where sm.ticketNumber.ToString() == ticketNumber.ToString()
                                     select sm).FirstOrDefault();


                        /*var queryDates = (from sm in db.Tickets
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
                        */

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
        private void ImportarDatosIntrumentacion()
        {
            var lastmonth = DateTime.Now.AddDays(-30);

            var query = (from s in db2.sites
                         join l in db2.loggers
                          on s.LoggerID equals l.ID
                         join a in db2.accounts
                          on s.OwnerAccount equals a.ID
                         where a.ID == 5 || a.ID == 6 || a.ID == 10
                         select new { l.LoggerSMSNumber, s.SiteID }).ToList();

            var maxid = (from m in db2.messages 
                         select m.ID).Max();

            var lastID = (from m in db2.messages
                          where m.rxtime < lastmonth
                          select m).Max(x => (int?)x.ID);

            var msg = (from m in db2.messages
                       where (int?)m.ID > lastID && m.ID < maxid
                       select new { m.battery, m.csq, m.rxtime }).ToList();

            foreach(var i in query)
            {
                var pivote = 0;
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings["Pivote"] ?? "Not Found";
                int counter = 0;
                int counter2 = 0;

                if (result == "Not Found")
                {
                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;
                    pivote = Convert.ToInt32(maxid);
                    settings.Add("Pivote", lastID.ToString());
                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                    
                    foreach (var k in msg)
                    {
                        BehaviorInstrumentation m = new BehaviorInstrumentation
                        {
                            siteIDDatagate = i.SiteID,
                            csq = k.csq,
                            battery = k.battery,
                            lastCallIn = k.rxtime
                        };
                        db.BehaviorInstrumentation.Add(m);
                        db.SaveChanges();
                        //query.GetEnumerator().MoveNext();
                        counter++;
                        if(counter >= 1)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    var oldpivote = Convert.ToInt32(appSettings.Get("Pivote"));

                    var newday = (from m in db2.messages where (int?)m.ID > oldpivote && m.ID < maxid select new { m.ID, m.battery, m.csq, m.rxtime }).ToList();

                    foreach(var x in newday)
                    {
                        BehaviorInstrumentation m = new BehaviorInstrumentation
                        {
                            //id = Convert.ToInt32(x.ID),
                            siteIDDatagate = i.SiteID,
                            csq = x.csq,
                            battery = x.battery,
                            lastCallIn = x.rxtime
                        };

                        db.BehaviorInstrumentation.Add(m);
                        db.SaveChanges();
                        counter2++;
                        if (counter2 >= 1)
                        {
                            break;
                        }
                    }
                }
            }

        }


        private List<string> getSitesID()
        {
                   
            var query = (from s in db2.sites
                        join l in db2.loggers
                        on s.LoggerID equals l.ID
                        join a in db2.accounts
                        on s.OwnerAccount equals a.ID
                        where a.ID == 5 || a.ID == 6 || a.ID == 10
                        select new { l.LoggerSMSNumber, s.SiteID }).ToList();

            if (query != null)
            {
               
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
                        var idTaskFieldBeat = dr["ID"];
                        /*sucursal*/
                        var idFieldBeat     = dr["Sucursal"];
                        var TaskType        = dr["Tipo de Tarea"];
                        var datetimeTask    = dr["Fecha Creación"];
                        var currentStatus   = dr["Último Estado"];
                        var suppliesUsed    = dr["Insumos Utilizados - Materiales Usados"];
    

                        var query = (from sm in db.TaskSuppliesUsed
                                     where sm.idTaskFieldbeat.ToString() == idTaskFieldBeat.ToString()
                                     select sm).FirstOrDefault();

                        //var suppliesquery = (from sm in db.TaskSuppliesUsed
                        //                     where sm.suppliesUsed.ToString().ToLower().Contains("bateria")  ||
                        //                           sm.suppliesUsed.ToString().ToLower().Contains("antena")   ||
                        //                           sm.suppliesUsed.ToString().ToLower().Contains("sim")      ||
                        //                           sm.suppliesUsed.ToString().ToLower().Contains("simcard")
                        //                     select sm).FirstOrDefault();

                        if (query == null)
                        {
                            TaskSuppliesUsed t = new TaskSuppliesUsed();

                            t.idFieldbeat      = Convert.ToString(idFieldBeat);
                            t.idTaskFieldbeat  = idTaskFieldBeat.ToString();
                            t.datetimeTask     = Convert.ToDateTime(datetimeTask);
                            t.TaskType         = TaskType.ToString();
                            t.suppliesUsed     = suppliesUsed.ToString();
                            t.currentStatus    = currentStatus.ToString();

                            if (t.currentStatus.Equals("TERMINADA"))
                            {
                                db.TaskSuppliesUsed.Add(t);
                            }
                            
                        } 
                        else {
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
        DataView ImportarTareasPreventivas(string filename)
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
                        var id            = dr["ID"];
                        var cliente       = dr["Cliente"];
                        var sucursal      = dr["Sucursal"];
                        var tasktype      = dr["Tipo de tarea"];
                        var createdate    = dr["Fecha Creación"];
                        var currentstatus = dr["Último Estado"];
                      
                        var query = (from sm in db.TareasPreventivas
                                     where sm.id.ToString() == id.ToString()
                                     select sm).FirstOrDefault();

                        if (query == null)
                        {
                            TareasPreventivas tp = new TareasPreventivas();

                            tp.cliente       = cliente.ToString();
                            tp.sucursal      = sucursal.ToString();
                            tp.tasktype      = tasktype.ToString();
                            tp.createdate    = Convert.ToDateTime(createdate);
                            tp.currentstatus = currentstatus.ToString();                         
                            
                            if (tp.currentstatus.Equals("TERMINADA"))
                            {
                                db.TareasPreventivas.Add(tp);
                            }

                        }
                        else
                        {
                            query.cliente       = cliente.ToString();
                            query.sucursal      = sucursal.ToString();
                            query.tasktype      = tasktype.ToString();
                            query.createdate    = Convert.ToDateTime(createdate);
                            query.currentstatus = currentstatus.ToString();
                            
                            if (query.currentstatus.Equals("TERMINADA"))
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

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog
        //    {
        //        Filter = "Excel | *.xls; *.xlsx;",
        //        Title = "Seleccionar Archivo"
        //    };

        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        dataGridView1.DataSource = ImportarDatosIntrumentacion();
        //    }
        //}

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

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls; *.xlsx;",
                Title = "Seleccionar Archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = ImportarTareasPreventivas(openFileDialog.FileName);
            }
        }
    }
}
