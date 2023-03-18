using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccess.Models
{
    public partial class ECourseDBContext : DbContext
    {
        public ECourseDBContext()
        {
        }

        public ECourseDBContext(DbContextOptions<ECourseDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseDocument> CourseDocuments { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizOption> QuizOptions { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<ResultDetail> ResultDetails { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentSemester> StudentSemesters { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectItem> SubjectItems { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =MINHNHUT\\NHUT57; Database = ECourseDB; Uid=sa; Pwd=05072001;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(50)
                    .HasColumnName("AdminID");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(50)
                    .HasColumnName("CourseID");

                entity.Property(e => e.LinkCourse)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SubjectID");

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TeacherID");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Subject");
            });

            modelBuilder.Entity<CourseDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.ToTable("CourseDocument");

                entity.Property(e => e.DocumentId)
                    .HasMaxLength(50)
                    .HasColumnName("DocumentID");

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CourseID");

                entity.Property(e => e.Defination).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Video).IsRequired();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseDocuments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseDocument_Course");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.MajorId)
                    .HasMaxLength(50)
                    .HasColumnName("MajorID");

                entity.Property(e => e.MajorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.QuizId)
                    .HasMaxLength(50)
                    .HasColumnName("QuizID");

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CourseID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_Course");
            });

            modelBuilder.Entity<QuizOption>(entity =>
            {
                entity.HasKey(e => e.OptionId);

                entity.ToTable("QuizOption");

                entity.Property(e => e.OptionId)
                    .HasMaxLength(50)
                    .HasColumnName("OptionID");

                entity.Property(e => e.OptionText).IsRequired();

                entity.Property(e => e.QuestionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("QuestionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuizOptions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuizOption_QuizQuestion");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("QuizQuestion");

                entity.Property(e => e.QuestionId)
                    .HasMaxLength(50)
                    .HasColumnName("QuestionID");

                entity.Property(e => e.Answer).IsRequired();

                entity.Property(e => e.Question).IsRequired();

                entity.Property(e => e.QuizId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("QuizID");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuizQuestion_Quiz");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("Result");

                entity.Property(e => e.ResultId)
                    .HasMaxLength(50)
                    .HasColumnName("ResultID");

                entity.Property(e => e.QuizId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("QuizID");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Result_Quiz");
            });

            modelBuilder.Entity<ResultDetail>(entity =>
            {
                entity.HasKey(e => new { e.ResultId, e.OptionId });

                entity.ToTable("ResultDetail");

                entity.Property(e => e.ResultId)
                    .HasMaxLength(50)
                    .HasColumnName("ResultID");

                entity.Property(e => e.OptionId)
                    .HasMaxLength(50)
                    .HasColumnName("OptionID");

                entity.Property(e => e.OptionText).IsRequired();

                entity.Property(e => e.Question).IsRequired();

                entity.Property(e => e.QuestionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("QuestionID");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.ResultDetails)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultDetail_QuizOption");

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.ResultDetails)
                    .HasForeignKey(d => d.ResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultDetail_Result");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.SemesterId)
                    .HasMaxLength(50)
                    .HasColumnName("SemesterID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.SemesterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .HasColumnName("StudentID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StudentSemesterId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("StudentSemesterID");

                entity.HasOne(d => d.StudentSemester)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StudentSemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_StudentSemester");
            });

            modelBuilder.Entity<StudentSemester>(entity =>
            {
                entity.ToTable("StudentSemester");

                entity.Property(e => e.StudentSemesterId)
                    .HasMaxLength(50)
                    .HasColumnName("StudentSemesterID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(50)
                    .HasColumnName("SubjectID");

                entity.Property(e => e.MajorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MajorID");

                entity.Property(e => e.SemesterId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SemesterID");

                entity.Property(e => e.StudentSemesterId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("StudentSemesterID");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TeacherID");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Major");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Semester");

                entity.HasOne(d => d.StudentSemester)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.StudentSemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_StudentSemester");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Teacher");
            });

            modelBuilder.Entity<SubjectItem>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.StudentId });

                entity.ToTable("SubjectItem");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(50)
                    .HasColumnName("SubjectID");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SubjectItems)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectItem_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectItems)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectItem_Subject");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(50)
                    .HasColumnName("TeacherID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
