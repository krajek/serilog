// Copyright 2013-2015 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;

namespace Serilog.Policies
{
    class StringLimitingConversionPolicy : IScalarConversionPolicy
    {
        private readonly int _maximumStringLength;

        public StringLimitingConversionPolicy(int maximumStringLength)
        {
            _maximumStringLength = maximumStringLength;
        }

        public bool TryConvertToScalar(object value, ILogEventPropertyValueFactory propertyValueFactory, out ScalarValue result)
        {
            var text = value as string;
            if (text != null)
            {
                var truncated = Truncation.Apply(text, _maximumStringLength);
                result = new ScalarValue(truncated);
                return true;
            }

            result = null;
            return false;
        }
    }
}
