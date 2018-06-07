using System;
using System.Web.UI;
using di_demo.Data;

namespace di_demo
{
    public partial class _Default : Page
    {
        private readonly IPersonRepository _repository;
        public _Default(IPersonRepository repository)
        {
            _repository = repository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            int id;

            divError.Visible = !Int32.TryParse(txtId.Text, out id);
            if (divError.Visible) return;

            var person = _repository.GetPerson(id);
            LabelId.Text = person.Id.ToString();
            LabelFirstName.Text = person.FirstName;
            LabelLastName.Text = person.LastName;
            LabelDob.Text = person.DateOfBirth.ToShortDateString();
            employeeData.Visible = true;
        }
    }
}