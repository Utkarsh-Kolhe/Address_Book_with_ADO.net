using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_With_ADO
{
    internal class BookOperations
    {
        static string connectionString = "Data Source=Utkarsh\\SQLEXPRESS;Initial Catalog=ado_Practice;Integrated Security=true;";

        public static void AddNewUser()
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(connectionString))
                {
                    con.Open();

                    Console.Write("Enter Phone Number: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter Email Address: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter City: ");
                    string city = Console.ReadLine();
                    Console.Write("Enter State: ");
                    string state = Console.ReadLine();
                    Console.Write("Enter Zip Code: ");
                    string zipCode = Console.ReadLine();

                    string insertQuery = "INSERT INTO AddressBook VALUES(@PhoneNumber, @FirstName, @LastName, @EmailAddress, @City, @State, @ZipCode)";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@EmailAddress", email);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@ZipCode", zipCode);

                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("\nContact Saved Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\nDidn\'t save contact");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void EditContactDetails()
        {
            SqlConnection con = null;
            try
            {
                using(con = new SqlConnection(connectionString))
                {
                    con.Open();

                    Console.Write("\nEnter phone number: ");
                    string phoneNumber = Console.ReadLine();

                    string selectQuery = "SELECT * FROM AddressBook";
                    SqlCommand cmd = new SqlCommand(selectQuery, con);

                    SqlDataReader dr = cmd.ExecuteReader();

                    bool check = false; // for if user not found

                    while (dr.Read())
                    {
                        if (dr["Phone Number"].ToString().CompareTo(phoneNumber) == 0)
                        {
                            check = true;

                            Console.WriteLine("\nOld Details");
                            Console.WriteLine("Phone Number: " + dr["Phone Number"]);
                            Console.WriteLine("First Name: " + dr["First Name"]);
                            Console.WriteLine("Last Name: " + dr["Last Name"]);
                            Console.WriteLine("Email: " + dr["Email Address"]);
                            Console.WriteLine("City: " + dr["City"]);
                            Console.WriteLine("State: " + dr["State"]);
                            Console.WriteLine("Zip Code: " + dr["Zip Code"]);

                            dr.Close();
                            break;
                        }
                    }
                    if(!check)
                    {
                        Console.WriteLine("\n" + phoneNumber + " not found in Address Book");
                    }
                    else
                    {
                        int choice;
                        do
                        {
                            Console.WriteLine("\n1. Edit Phone number.");
                            Console.WriteLine("2. Edit First name.");
                            Console.WriteLine("3. Edit Last Name.");
                            Console.WriteLine("4. Edit Email Address.");
                            Console.WriteLine("5. Edit City.");
                            Console.WriteLine("6. Edit State.");
                            Console.WriteLine("7. Edit Zip Code.");
                            Console.WriteLine("8. Go back to main menu.");

                            Console.Write("Enter choice: ");
                            choice = Convert.ToInt32(Console.ReadLine());

                            switch (choice)
                            {
                                case 1: // phone number
                                    Console.Write("Enter new phone number: ");
                                    string phoneNum = Console.ReadLine();
                                    string phoneNumberUpdateQuery = "UPDATE AddressBook SET [Phone Number] = @phoneNum  where [Phone Number] = @phoneNumber";
                                    SqlCommand cmdPhone = new SqlCommand(phoneNumberUpdateQuery, con);
                                    cmdPhone.Parameters.AddWithValue("@phoneNum", phoneNum);
                                    cmdPhone.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                                    if(cmdPhone.ExecuteNonQuery() != 0)
                                    {
                                        Console.WriteLine("\nPhone number updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nUnable to update Phone number.");
                                    }
                                    break;

                                case 2: // first name
                                    Console.Write("Enter new first name: ");
                                    string firstName = Console.ReadLine();
                                    string firstNameUpdateQuery = "UPDATE AddressBook SET [First Name] = @firstName where [Phone Number] = @phoneNumber";
                                    SqlCommand cmdFirstName = new SqlCommand(firstNameUpdateQuery, con);
                                    cmdFirstName.Parameters.AddWithValue("@firstName", firstName);
                                    cmdFirstName.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                                    if (cmdFirstName.ExecuteNonQuery() != 0)
                                    {
                                        Console.WriteLine("\nFirst name updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nUnable to update first name.");
                                    }
                                    break;

                                case 3: // last name
                                    Console.Write("Enter new last name: ");
                                    string lastName = Console.ReadLine();
                                    string lastNameUpdateQuery = "UPDATE AddressBook SET [Last Name] = @lastName  where [Phone Number] = @phoneNumber";
                                    SqlCommand cmdLastName = new SqlCommand(lastNameUpdateQuery, con);
                                    cmdLastName.Parameters.AddWithValue("@lastName", lastName);
                                    cmdLastName.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                                    if (cmdLastName.ExecuteNonQuery() != 0)
                                    {
                                        Console.WriteLine("\nLast name updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nUnable to update last name.");
                                    }
                                    break;

                                case 4: // email
                                    Console.Write("Enter new email: ");
                                    string email = Console.ReadLine();
                                    string emailUpdateQuery = "UPDATE AddressBook SET [Email Address] = @email WHERE [Phone Number] = @phoneNumber";
                                    SqlCommand cmdEmail = new SqlCommand(emailUpdateQuery, con);
                                    cmdEmail.Parameters.AddWithValue("@email", email);
                                    cmdEmail.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                                    if(cmdEmail.ExecuteNonQuery() != 0)
                                    {
                                        Console.WriteLine("\nEmail updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nUnable to update email.");
                                    }
                                    break;

                                case 5: // city
                                    Console.Write("Enter new city: ");
                                    string city = Console.ReadLine();
                                    string cityUpdateQuery = "UPDATE AddressBook SET [City] = @city WHERE [Phone Number] = @phoneNumber";
                                    SqlCommand cmdCity = new SqlCommand(cityUpdateQuery, con);
                                    cmdCity.Parameters.AddWithValue("@city", city);
                                    cmdCity.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                                    if (cmdCity.ExecuteNonQuery() != 0)
                                    {
                                        Console.WriteLine("\nCity updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nUnable to update city.");
                                    }
                                    break;

                                case 6: // state
                                    Console.Write("Enter new state: ");
                                    string state = Console.ReadLine();
                                    string stateUpdateQuery = "UPDATE AddressBook SET [State] = @State WHERE [Phone Number] = @phoneNumber";
                                    SqlCommand cmdState = new SqlCommand(stateUpdateQuery, con);
                                    cmdState.Parameters.AddWithValue("@state", state);
                                    cmdState.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                                    if (cmdState.ExecuteNonQuery() != 0)
                                    {
                                        Console.WriteLine("\nState updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nUnable to update state.");
                                    }
                                    break;

                                case 7: // zipcode
                                    Console.Write("Enter new zip code: ");
                                    string zipCode = Console.ReadLine();
                                    string zipCodeUpdateQuery = "UPDATE AddressBook SET [Zip Code] = @zipCode WHERE [Phone Number] = @phoneNumber";
                                    SqlCommand cmdZipCode = new SqlCommand(zipCodeUpdateQuery, con);
                                    cmdZipCode.Parameters.AddWithValue("@zipCode", zipCode);
                                    cmdZipCode.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                                    if (cmdZipCode.ExecuteNonQuery() != 0)
                                    {
                                        Console.WriteLine("\nZop code updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nUnable to update zip code.");
                                    }
                                    break;

                                case 8: // main menu
                                    Console.WriteLine("\nMain Menu");
                                    break;

                                default: // invalid choice
                                    Console.WriteLine("\nInvalid Choice! ! !");
                                    break;
                            }
                        } while (choice != 8);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine (e.Message);
            }
            finally
            {
                con.Close ();
            }
        }


        public static void DeleteContact()
        {
            Console.Write("\nEnter phone number: ");
            string phoneNumber = Console.ReadLine();

            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string selectQuery = "SELECT * FROM AddressBook";
                    SqlCommand cmd = new SqlCommand (selectQuery, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    bool check = false;
                    while (dr.Read())
                    {
                        if (dr["Phone Number"].ToString().CompareTo(phoneNumber) == 0)
                        {
                            check = true;
                            dr.Close();
                            break;
                        }
                    }
                    if (check)
                    {
                        SqlCommand deleteCmd = new SqlCommand("DELETE FROM AddressBook WHERE [Phone Number] = @phoneNumber", con);
                        deleteCmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        deleteCmd.ExecuteNonQuery();
                        Console.WriteLine("\nContact delete successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\nUser not found! ! !");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine (e.Message);
            }
            finally
            {
                con.Close ();
            }
        }

        public static void PrintData()
        {
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string selectQuery = "SELECT * FROM AddressBook";
                    SqlCommand cmd = new SqlCommand ( selectQuery, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine("\nPhone Number: " + dr["Phone Number"]);
                            Console.WriteLine("First Name: " + dr["First Name"]);
                            Console.WriteLine("Last Name: " + dr["Last Name"]);
                            Console.WriteLine("Email: " + dr["Email Address"]);
                            Console.WriteLine("City: " + dr["City"]);
                            Console.WriteLine("State: " + dr["State"]);
                            Console.WriteLine("Zip Code: " + dr["Zip Code"] + "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nDatabase is Empty");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine (e.Message);
            }
            finally
            {
                con.Close ();
            }
        }
    }
}
