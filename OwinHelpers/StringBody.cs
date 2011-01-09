﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwinHelpers
{
    public class StringBody : IObservable<byte[]>
    {
        private readonly byte[] _bytes;

        public StringBody(string text) : this(text, Encoding.Default)
        {
        }

        public StringBody(string text, Encoding encoding)
        {
            _bytes = encoding.GetBytes(text);
        }

        public int Length
        {
            get { return _bytes.Length; }
        }

        public IDisposable Subscribe(IObserver<byte[]> observer)
        {
            observer.OnNext(_bytes);
            observer.OnCompleted();
            return new NullDisposable();
        }

    }
}
