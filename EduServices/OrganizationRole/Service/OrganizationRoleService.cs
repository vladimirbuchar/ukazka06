using Core.Base.Service;
using Core.DataTypes;
using EduRepository.AnswerRepository;
using EduRepository.BankOfQuestionRepository;
using EduRepository.BranchRepository;
using EduRepository.CertificateRepository;
using EduRepository.ClassRoomRepository;
using EduRepository.CourseLessonItemRepository;
using EduRepository.CourseLessonRepository;
using EduRepository.CourseMaterialRepository;
using EduRepository.CourseRepository;
using EduRepository.CourseStudentRepository;
using EduRepository.CourseTermRepository;
using EduRepository.OrganizationCultureRepository;
using EduRepository.OrganizationHoursRepository;
using EduRepository.OrganizationRoleRepository;
using EduRepository.PermissionsRepository;
using EduRepository.QuestionRepository;
using EduRepository.SendMessageRepository;
using EduRepository.StudentGroupRepository;
using EduRepository.UserInOrganizationRepository;
using EduServices.OrganizationRole.Convertor;
using Model.Tables.Edu.OrganizationRole;
using Model.Tables.System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.OrganizationRole.Service
{
    public class OrganizationRoleService(
        ICourseStudentRepository courseStudentRepository,
        IOrganizationCultureRepository organizationCultureRepository,
        IStudentGroupRepository studentGroupRepository,
        ICourseTermRepository courseTermRepository,
        IOrganizationStudyHourRepository organizationStudyHoursRepository,
        ISendMessageRepository sendMessageRepository,
        ICourseLessonItemRepository courseLessonItemRepository,
        ICourseLessonRepository courseLessonRepository,
        ICourseMaterialRepository courseMaterialRepository,
        ICourseRepository courseRepository,
        ICertificateRepository certificateRepository,
        IAnswerRepository answerRepository,
        IQuestionRepository questionRepository,
        IBankOfQuestionRepository bankOfQuestionRepository,
        IClassRoomRepository classRoomRepository,
        IBranchRepository branchRepository,
        IUserInOrganizationRepository userInOrganizationRepository,
        IOrganizationRoleRepository organizationRoleRepository,
        IOrganizationRoleConvertor convertor,
        IPermissionsRepository permissionsRepository
    ) : BaseService<IOrganizationRoleRepository, OrganizationRoleDbo, IOrganizationRoleConvertor>(organizationRoleRepository, convertor), IOrganizationRoleService
    {
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;
        private readonly IBranchRepository _branchRepository = branchRepository;
        private readonly IClassRoomRepository _classRoomRepository = classRoomRepository;
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository = bankOfQuestionRepository;
        private readonly IQuestionRepository _questionRepository = questionRepository;
        private readonly IAnswerRepository _answerRepository = answerRepository;
        private readonly ICertificateRepository _certificateRepository = certificateRepository;
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly ICourseMaterialRepository _courseMaterialRepository = courseMaterialRepository;
        private readonly ICourseLessonRepository _courseLessonRepository = courseLessonRepository;
        private readonly ICourseLessonItemRepository _courseLessonItemRepository = courseLessonItemRepository;
        private readonly ISendMessageRepository _sendMessageRepository = sendMessageRepository;
        private readonly IOrganizationStudyHourRepository _organizationStudyHoursRepository = organizationStudyHoursRepository;
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;
        private readonly IStudentGroupRepository _studentGroupRepository = studentGroupRepository;
        private readonly IOrganizationCultureRepository _organizationCultureRepository = organizationCultureRepository;
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly IPermissionsRepository _permissionsRepository = permissionsRepository;

        public bool CheckPermition(Guid userId, Guid organizationId, string route, List<string> roles)
        {
            HashSet<PermissionsDbo> permissions = _permissionsRepository.GetEntities(false, x => x.Route.Route == route.Trim('/') && x.OrganizationRole.UserInOrganizations.Any(y => y.OrganizationId == organizationId) && x.OrganizationRole.UserInOrganizations.Any(y => y.UserId == userId) && roles.Contains(x.OrganizationRole.SystemIdentificator));
            return permissions.Count > 0;
        }

        public Guid GetOrganizationIdByBranch(Guid branchId)
        {
            return _branchRepository.GetOrganizationId(branchId);
        }

        public Guid GetOrganizationIdByClassRoom(Guid classRoomId)
        {
            return _classRoomRepository.GetOrganizationId(classRoomId);
        }

        public Guid GetOrganizationByCourseLesson(Guid courseLessonId)
        {
            return _courseLessonRepository.GetOrganizationId(courseLessonId);
        }

        public Guid GetOrganizationIdByCourseId(Guid courseId)
        {
            return _courseRepository.GetOrganizationId(courseId);
        }

        public Guid GetOrganizationIdByTermId(Guid termId)
        {
            return _courseTermRepository.GetOrganizationId(termId);
        }

        public Guid GetOrganizationByUserInOrganization(Guid id)
        {
            return _userInOrganizationRepository.GetOrganizationId(id);
        }

        public Guid GetOrganizationByOrganizationStudyHour(Guid id)
        {
            return _organizationStudyHoursRepository.GetOrganizationId(id);
        }

        public Guid GetOrganizationByCourseLessonItem(Guid courseLessonItemId)
        {
            return _courseLessonItemRepository.GetOrganizationId(courseLessonItemId);
        }

        public Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestionId)
        {
            return _bankOfQuestionRepository.GetOrganizationId(bankOfQuestionId);
        }

        public Guid GetOrganizationIdByQuestion(Guid questionId)
        {
            return _questionRepository.GetOrganizationId(questionId);
        }

        public Guid GetOrganizationByAnswer(Guid answerId)
        {
            return _answerRepository.GetOrganizationId(answerId);
        }

        public Guid GetOrganizationByStudentId(Guid studentId)
        {
            return _courseStudentRepository.GetOrganizationId(studentId);
        }

        public Guid GetOrganizationByCertificateId(Guid certificateId)
        {
            return _certificateRepository.GetOrganizationId(certificateId);
        }

        public Guid GetOrganizationBySendMessage(Guid sendMessageId)
        {
            return _sendMessageRepository.GetOrganizationId(sendMessageId);
        }

        public Guid GetOrganizationByStudentGroupId(Guid studentGroupId)
        {
            return _studentGroupRepository.GetOrganizationId(studentGroupId);
        }

        public Guid GetOrganizationByCourseMaterial(Guid courseMaterialId)
        {
            return _courseMaterialRepository.GetOrganizationId(courseMaterialId);
        }

        public Guid GetOrganizationByOrganizationCulture(Guid id)
        {
            return _organizationCultureRepository.GetOrganizationId(id);
        }

        public bool CheckPermition(Guid userId, Guid organizationId, OperationType operationType)
        {
            throw new NotImplementedException();
        }
    }
}
