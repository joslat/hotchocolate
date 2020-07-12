using System;
using System.Reflection;
using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;

namespace HotChocolate.Data.Filters
{
    public class FilterOperationFieldDescriptor
        : ArgumentDescriptorBase<FilterOperationFieldDefinition>
        , IFilterOperationFieldDescriptor
    {
        protected FilterOperationFieldDescriptor(
            IDescriptorContext context,
            string? scope,
            int operation)
            : base(context)
        {
            IFilterConvention? convention = context.GetFilterConvention(scope);
            Definition.Operation = operation;
            Definition.Name = convention.GetOperationName(context, operation);
            Definition.Description = convention.GetOperationDescription(context, operation);
            Definition.Scope = scope;
        }

        protected override void OnCreateDefinition(
            FilterOperationFieldDefinition definition)
        {
            if (Definition.Property is { })
            {
                Context.Inspector.ApplyAttributes(Context, this, Definition.Property);
            }

            base.OnCreateDefinition(definition);
        }

        public new IFilterOperationFieldDescriptor SyntaxNode(
            InputValueDefinitionNode inputValueDefinition)
        {
            base.SyntaxNode(inputValueDefinition);
            return this;
        }

        public IFilterOperationFieldDescriptor Name(NameString value)
        {
            Definition.Name = value.EnsureNotEmpty(nameof(value));
            return this;
        }

        public IFilterOperationFieldDescriptor Ignore(bool ignore = true)
        {
            Definition.Ignore = ignore;
            return this;
        }

        public new IFilterOperationFieldDescriptor Description(string value)
        {
            base.Description(value);
            return this;
        }

        public new IFilterOperationFieldDescriptor Type<TInputType>()
            where TInputType : IInputType
        {
            base.Type<TInputType>();
            return this;
        }

        public new IFilterOperationFieldDescriptor Type<TInputType>(
            TInputType inputType)
            where TInputType : class, IInputType
        {
            base.Type(inputType);
            return this;
        }

        public new IFilterOperationFieldDescriptor Type(ITypeNode typeNode)
        {
            base.Type(typeNode);
            return this;
        }

        public new IFilterOperationFieldDescriptor Type(Type type)
        {
            base.Type(type);
            return this;
        }

        public IFilterOperationFieldDescriptor Operation(int operation)
        {
            Definition.Operation = operation;
            return this;
        }

        public new IFilterOperationFieldDescriptor DefaultValue(
            IValueNode value)
        {
            base.DefaultValue(value);
            return this;
        }

        public new IFilterOperationFieldDescriptor DefaultValue(object value)
        {
            base.DefaultValue(value);
            return this;
        }

        public new IFilterOperationFieldDescriptor Directive<TDirective>(
            TDirective directiveInstance)
            where TDirective : class
        {
            base.Directive(directiveInstance);
            return this;
        }

        public new IFilterOperationFieldDescriptor Directive<TDirective>()
            where TDirective : class, new()
        {
            base.Directive<TDirective>();
            return this;
        }

        public new IFilterOperationFieldDescriptor Directive(
            NameString name,
            params ArgumentNode[] arguments)
        {
            base.Directive(name, arguments);
            return this;
        }

        public InputFieldDefinition CreateFieldDefinition() => CreateDefinition();

        public static FilterOperationFieldDescriptor New(
            IDescriptorContext context,
            string? scope,
            int operation)
            => new FilterOperationFieldDescriptor(context, scope, operation);
    }
}
