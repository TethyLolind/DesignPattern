using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ConsoleApp11_decorator__
{
    class DecoratorForFileStream:FileStream
    {
        public DecoratorForFileStream(FileStream input):base(FileStream input)
        {
             
        }

        public int read(byte[] ByteArray, int offset, int len)
        {
            try
            {
                int result= base.Read( ByteArray,offset,len);
                for (int i = 0; i < offset+result; i++)
                {
                    ByteArray[i] = (byte) Char.ToLower((char)ByteArray[i]);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
