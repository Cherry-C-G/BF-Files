using CourseDaoApplication.Data;

namespace CourseDaoMVC.Services.Contract
{
    public interface IProfessorDAO
    {
        void AddProfessor(Professor professor);
        void UpdateProfessor(Professor professor);
        Professor FindProfessorById(int id);
        List<Professor> GetAllProfessor();
        void DeleteProfessor(int id);
    }
}
