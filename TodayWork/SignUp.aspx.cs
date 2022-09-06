using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MoviesCrud
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (isformvalid())
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into tblUsers(Username, Password, Email, Name) Values('" + username.Text + "', '" + password.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('Registered');</script>");
                con.Close();
                Response.Redirect("SignIn.aspx");
            }
            else
            {
                Response.Write("<script> alert('Registeration Failed');</script>");
            }
            
        }

        private bool isformvalid()
        {
            if (username.Text == "")
            {
                Response.Write("<script> alert('username not valid');  </script>");
                

                return false;
            }
            else if (password.Text == "")
            {
                Response.Write("<script> alert('Password not valid');  </script>");
               
                return false;
            }
           
            else if (TextBox3.Text == "")
            {
                Response.Write("<script> alert('Email not valid');  </script>");
                
                return false;
            }
            else if (TextBox4.Text == "")
            {
                Response.Write("<script> alert('Name not valid');  </script>");
                
                return false;
            }

            return true;
        }
    }
}
