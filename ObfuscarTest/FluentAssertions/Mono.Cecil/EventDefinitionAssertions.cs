﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Mono.Cecil;
using Obfuscar;

namespace ObfuscarTest.FluentAssertions.Mono.Cecil
{
    /// <summary>
    /// <see cref="TypeDefinition"/> assertions based on <inheritdoc cref="ReferenceTypeAssertions{TSubject,TAssertions}"/>
    /// </summary>
    public class EventDefinitionAssertions : ReferenceTypeAssertions<EventDefinition, EventDefinitionAssertions>
    {
        /// <summary> Constructor </summary>
        /// <param name="instance">The instance to assert.</param>
        public EventDefinitionAssertions(EventDefinition instance)
            : base(instance)
        { }

        /// <inheritdoc cref = "ReferenceTypeAssertions{TSubject,TAssertions}.Identifier" />
        protected override string Identifier => "PropertyDefinition";

        /// <summary>
        /// Assert the <see cref="ReferenceTypeAssertions{TSubject,TAssertions}.Subject"/> to have a specific obfuscation status
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the
        /// assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see paramref="because" />.
        /// </param>
        /// <param name="map">The obfuscation map to use for lookup.</param>
        /// <param name="status">The obfuscation status to compare with.</param>
        internal AndConstraint<EventDefinitionAssertions> HaveObfuscationStatus(
            ObfuscationMap map, ObfuscationStatus status, 
            string because = "", params object[] becauseArgs)
        {
            Execute.Assertion.AddReportable("status",
                () => Subject != null
                    ? map.GetEvent(new EventKey(Subject))?.Status.ToString()
                    : null);

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(map.GetEvent(new EventKey(Subject))?.Status == status)
                .FailWith("Expected {context:" + Identifier + "} " +
                          "for event {0} to have obfuscation status {1} but found status {status}.",
                    Subject, status);

            return new AndConstraint<EventDefinitionAssertions>(this);
        }

        /// <summary>
        /// Assert the <see cref="ReferenceTypeAssertions{TSubject,TAssertions}.Subject"/> to have a specific obfuscation status
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the
        /// assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see paramref="because" />.
        /// </param>
        /// <param name="map">The obfuscation map to use for lookup.</param>
        /// <param name="status">The obfuscation statuses to compare with.</param>
        internal AndConstraint<EventDefinitionAssertions> HaveObfuscationStatus(
            ObfuscationMap map, IEnumerable<ObfuscationStatus> status,
            string because = "", params object[] becauseArgs)
        {
            Execute.Assertion.AddReportable("status",
                () => Subject != null
                    ? map.GetEvent(new EventKey(Subject))?.Status.ToString()
                    : null);

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(status.Any(s => map.GetEvent(new EventKey(Subject))?.Status != s))
                .FailWith("Expected {context:" + Identifier + "} " +
                          "for event {0} to have any of obfuscation status {1} but found status {status}.",
                    Subject, status);

            return new AndConstraint<EventDefinitionAssertions>(this);
        }

        /// <summary>
        /// Assert the <see cref="ReferenceTypeAssertions{TSubject,TAssertions}.Subject"/> not to have a specific obfuscation status
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the
        /// assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see paramref="because" />.
        /// </param>
        /// <param name="map">The obfuscation map to use for lookup.</param>
        /// <param name="status">The obfuscation status to compare with.</param>
        internal AndConstraint<EventDefinitionAssertions> NotHaveObfuscationStatus(
            ObfuscationMap map, ObfuscationStatus status,
            string because = "", params object[] becauseArgs)
        {
            Execute.Assertion.AddReportable("status",
                () => Subject != null
                    ? map.GetEvent(new EventKey(Subject))?.Status.ToString()
                    : null);

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(map.GetEvent(new EventKey(Subject))?.Status != status)
                .FailWith("Expected {context:" + Identifier + "} " + 
                          "for event {0} not to have obfuscation status {1} but found status {status}.",
                    Subject, status);

            return new AndConstraint<EventDefinitionAssertions>(this);
        }

        /// <summary>
        /// Assert the <see cref="ReferenceTypeAssertions{TSubject,TAssertions}.Subject"/> not to have a specific obfuscation status
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the
        /// assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see paramref="because" />.
        /// </param>
        /// <param name="map">The obfuscation map to use for lookup.</param>
        /// <param name="status">The obfuscation statuses to compare with.</param>
        internal AndConstraint<EventDefinitionAssertions> NotHaveObfuscationStatus(
            ObfuscationMap map, IEnumerable<ObfuscationStatus> status,
            string because = "", params object[] becauseArgs)
        {
            Execute.Assertion.AddReportable("status",
                () => Subject != null
                    ? map.GetEvent(new EventKey(Subject))?.Status.ToString()
                    : null);

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(status.All(s => map.GetEvent(new EventKey(Subject))?.Status != s))
                .FailWith("Expected {context:" + Identifier + "} " +
                          "for event {0} not to have and of obfuscation statuses {1} but found status {status}.",
                    Subject, status);

            return new AndConstraint<EventDefinitionAssertions>(this);
        }
    }
}
