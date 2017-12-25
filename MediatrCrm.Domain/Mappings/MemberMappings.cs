using MediatrCrm.Domain.Models;
using MediatrCrm.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace MediatrCrm.Domain
{
    public static class MemberMappings
    {
        /// <summary>
        /// Convert Member to MemberDefaultViewModel
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static MemberDefaultViewModel ToDefaultMemberViewModel(this Member member)
        {
            if(member == null)
            {
                return null;
            }

            return new MemberDefaultViewModel
            {
                Id = member.UniqueId,
                FirstName = member.FirstName,
                LastName = member.LastName
            };
        }

        /// <summary>
        /// Convert IEnumerable<Member> to IEnumerable<MemberDefaultViewModel>
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public static IEnumerable<MemberDefaultViewModel> ToDefaultMemberViewModel(this IEnumerable<Member> members)
        {
            return members.Select(ToDefaultMemberViewModel);
        }
    }
}
