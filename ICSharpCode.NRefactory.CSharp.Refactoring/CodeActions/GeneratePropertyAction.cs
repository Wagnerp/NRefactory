﻿// 
// GenerateProperty.cs
//  
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
// 
// Copyright (c) 2012 Xamarin Inc. (http://xamarin.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ICSharpCode.NRefactory6.CSharp.Refactoring;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.Formatting;

namespace ICSharpCode.NRefactory6.CSharp.Refactoring
{
	[NRefactoryCodeRefactoringProvider(Description = "Generates a getter and setter for a field")]
	[ExportCodeRefactoringProvider("Generate property", LanguageNames.CSharp)]
	public class GeneratePropertyAction : CodeRefactoringProvider
	{
		public override async Task ComputeRefactoringsAsync(CodeRefactoringContext context)
		{
			var document = context.Document;
			var span = context.Span;
			var cancellationToken = context.CancellationToken;
			var model = await document.GetSemanticModelAsync(cancellationToken);
			var root = await model.SyntaxTree.GetRootAsync(cancellationToken);
		}
//		public async Task ComputeRefactoringsAsync(Document document, TextSpan span, CancellationToken cancellationToken)
//		{
//			var initializer = context.GetNode<VariableInitializer>();
//			if (initializer == null || !initializer.NameToken.Contains(context.Location.Line, context.Location.Column)) {
//				yield break;
//			}
//			var type = initializer.Parent.Parent as TypeDeclaration;
//			if (type == null) {
//				yield break;
//			}
//			foreach (var member in type.Members) {
//				if (member is PropertyDeclaration && ContainsGetter((PropertyDeclaration)member, initializer)) {
//					yield break;
//				}
//			}
//			var field = initializer.Parent as FieldDeclaration;
//			if (field == null || field.HasModifier(Modifiers.Readonly) || field.HasModifier(Modifiers.Const)) {
//				yield break;
//			}
//			var resolveResult = context.Resolve(initializer) as MemberResolveResult;
//			if (resolveResult == null)
//				yield break;
//			yield return new CodeAction(context.TranslateString("Create property"), script => {
//				var fieldName = context.GetNameProposal(initializer.Name, true);
//				if (initializer.Name == context.GetNameProposal(initializer.Name, false)) {
//					script.Rename(resolveResult.Member, fieldName);
//				}
//				script.InsertWithCursor(
//					context.TranslateString("Create property"),
//					Script.InsertPosition.After, GeneratePropertyDeclaration(context, field, fieldName));
//			}, initializer);
//		}
//		
//		static PropertyDeclaration GeneratePropertyDeclaration (SemanticModel context, FieldDeclaration field, string fieldName)
//		{
//			var mod = ICSharpCode.NRefactory6.CSharp.Modifiers.Public;
//			if (field.HasModifier (ICSharpCode.NRefactory6.CSharp.Modifiers.Static))
//				mod |= ICSharpCode.NRefactory6.CSharp.Modifiers.Static;
//			
//			return new PropertyDeclaration () {
//				Modifiers = mod,
//				Name = context.GetNameProposal (fieldName, false),
//				ReturnType = field.ReturnType.Clone (),
//				Getter = new Accessor {
//					Body = new BlockStatement {
//						new ReturnStatement (new IdentifierExpression (fieldName))
//					}
//				},
//				Setter = new Accessor {
//					Body = new BlockStatement {
//						new AssignmentExpression (new IdentifierExpression (fieldName), new IdentifierExpression ("value"))
//					}
//				}
//			};
//		}
//		
//		bool ContainsGetter (PropertyDeclaration property, VariableInitializer initializer)
//		{
//			if (property.Getter.IsNull || property.Getter.Body.Statements.Count () != 1)
//				return false;
//			var ret = property.Getter.Body.Statements.Single () as ReturnStatement;
//			if (ret == null)
//				return false;
//			return ret.Expression.IsMatch (new IdentifierExpression (initializer.Name)) || 
//				ret.Expression.IsMatch (new MemberReferenceExpression (new ThisReferenceExpression (), initializer.Name));
//		}
//		

	}
}

