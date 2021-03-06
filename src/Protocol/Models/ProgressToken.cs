using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OmniSharp.Extensions.LanguageServer.Protocol.Models
{
    public class ProgressToken : IEquatable<ProgressToken>, IEquatable<long>, IEquatable<string>
    {
        private long? _long;
        private string _string;

        public ProgressToken(long value)
        {
            _long = value;
            _string = null;
        }
        public ProgressToken(string value)
        {
            _long = null;
            _string = value;
        }

        public bool IsLong => _long.HasValue;
        public long Long
        {
            get => _long ?? 0;
            set
            {
                String = null;
                _long = value;
            }
        }

        public bool IsString => _string != null;
        public string String
        {
            get => _string;
            set
            {
                _string = value;
                _long = null;
            }
        }

        public static implicit operator ProgressToken(long value)
        {
            return new ProgressToken(value);
        }

        public static implicit operator ProgressToken(string value)
        {
            return new ProgressToken(value);
        }

        public ProgressParams Create<T>(T value, JsonSerializer jsonSerializer)
        {
            return ProgressParams.Create<T>(this, value, jsonSerializer);
        }

        public override bool Equals(object obj)
        {
            return obj is ProgressToken token &&
                   this.Equals(token);
        }

        public override int GetHashCode()
        {
            var hashCode = 1456509845;
            hashCode = hashCode * -1521134295 + IsLong.GetHashCode();
            hashCode = hashCode * -1521134295 + Long.GetHashCode();
            hashCode = hashCode * -1521134295 + IsString.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(String);
            return hashCode;
        }

        public bool Equals(ProgressToken other)
        {
            return IsLong == other.IsLong &&
                   Long == other.Long &&
                   IsString == other.IsString &&
                   String == other.String;
        }

        public bool Equals(long other)
        {
            return this.IsLong && this.Long == other;
        }

        public bool Equals(string other)
        {
            return this.IsString && this.String == other;
        }
    }
}
