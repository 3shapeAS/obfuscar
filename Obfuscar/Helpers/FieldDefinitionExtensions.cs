﻿using Mono.Cecil;

namespace Obfuscar.Helpers
{
    internal static class FieldDefinitionExtensions
    {
        public static bool IsPublic(this FieldDefinition field)
        {
            return field != null && (field.IsPublic || field.IsFamily || field.IsFamilyOrAssembly);
        }

        /*
            See ECMA-335, Partition II, 23.1.10, for a description of the possible
            accessibility flags:

            CompilerControlled 0x0000 Member not referenceable
            Private 0x0001 Accessible only by the parent type
            FamANDAssem 0x0002 Accessible by sub-types only in this Assembly
            Assem 0x0003 Accessibly by anyone in the Assembly
            Family 0x0004 Accessible only by type and sub-types
            FamORAssem 0x0005 Accessibly by sub-types anywhere, plus anyone in assembly
            Public 0x0006 Accessibly by anyone who has visibility to this scope

            See more in Mono.Cecil.MethodAttributes flags enum 
            and Mono.Cecil.MethodAttributes.GetMaskedAttributes calls in Mono.Cecil.MethodDefinition

            TODO: look into mono-tools for Gendarme.Framework.Rocks regarding IsVisible - combined with our IsFamily or IsFamilyOrAssembly for properties or in general could be a good solution.
        */
        /// <summary> Detect if method is accessible as public or internal </summary>
        public static bool IsPublicOrInternal(this FieldDefinition field)
        {
            return field != null &&
                   !field.IsCompilerControlled &&
                   !field.IsPrivate &&                 //private
                   (
                       field.IsPublic ||               //public
                       field.IsAssembly ||             //internal
                       //field.IsFamily ||             //protected
                       field.IsFamilyAndAssembly ||
                       field.IsFamilyOrAssembly
                   );
        }
    }
}
