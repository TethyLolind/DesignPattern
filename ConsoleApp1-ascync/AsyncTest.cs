using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1_ascync
{
    class AsyncTest
    {
        private int i = 0;

        public void AsyncTest1()
        {

            Task<int> t1 = new Task<int>(() =>
            {
                i++;
                //
                return i;
            });
            Task t2 = t1.ContinueWith((antecedent) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(antecedent.Result);
                TaskScheduler
                    .FromCurrentSynchronizationContext(); //这是一个同步上下文的taskscheduler，原理就是把繁重的耗时工作丢给ThreadPool，然后将更新UI的操作丢给 UI线程的
            });

            t1.Start();


            //Task.WaitAll(t1,t2);
            if (t2.IsCompleted)
            {
                Console.WriteLine("!!t2complete");
            }

            if (t1.IsCompleted)
            {
                Console.WriteLine("!!t1complete");
            }
        }

        public void FacadeTask()
        {
            //
            TaskCompletionSource<int> a = new TaskCompletionSource<int>(0);
            //  
            var task = a.Task;
        }

        public void AnotherContiniue()
        {
            Task t1 = Task.Factory.StartNew(() => { Console.WriteLine("task 1"); });
            Task t2 = Task.Factory.StartNew(() =>
            {
                t1.Wait();
                Console.WriteLine("task 2 continue");
            });
        }

        public void WaitAll()
        {
            Task<int> t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task 1");
                return 1;
            });
            Task<int> t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task 2");
                return 2;
            });
            Task<int> t3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task 3");
                return 3;
            });
            Task<int> t4 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task 4");
                return 4;
            });
            var taskList = new List<Task<int>>() {t1, t2, t3, t4};

            while (taskList.Count > 0)
            {
                var index = Task.WaitAny(taskList.ToArray());
                taskList.RemoveAt(index);
                //投机性 可能会出现错的进程这样就不会有影响了
            }
        }


        public void ExceptionHandlering()
        {
            Task<int> t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task 1");
                return 1;
            });
            Task<int> t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task 2");
                return 2;
            });
            Task<int> t3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task 3");
                return 3;
            });
            Task<int> t4 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task 4");
                return 4;
            });
            var taskList = new List<Task<int>>() {t1, t2, t3, t4};

            while (taskList.Count > 0)
            {
                var index = Task.WaitAny(taskList.ToArray());

                try
                {
                    var result = taskList[index].Result;
                    //taskList[index].Wait();   
                    //if (taskList[index].Exception !=null){} 

                    //above都可以出发异常的rethrow
                }
                catch (AggregateException ae)
                {
                    Console.WriteLine(ae.InnerExceptions);
                    ae = ae.Flatten(); //如果在task里又开新的task 避免异常嵌套 用这个来处理ae
                    foreach (var exception in ae.InnerExceptions)
                    {
                        Console.WriteLine(exception);
                    }
                }

                taskList.RemoveAt(index);

            }
        }

        public void CancleToken()
        {
            CancellationTokenSource tokenSource=new CancellationTokenSource();
            var token = tokenSource.Token;

            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        Runing(token);
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException is OperationCanceledException)
                        {
                            Console.WriteLine("任务1被终止了", e);
                        }
                    }
                    
                },
                token
            );

            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        Runing(token);
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException is OperationCanceledException)
                        {
                            Console.WriteLine("任务2被终止了", e);
                        }
                    }

                },
                token
            );

            void CancelTrigger()
            {
                tokenSource.Cancel();//用source里面的cancel方法来终止
                tokenSource=new CancellationTokenSource();//更新一下source 否则token就一直被停住了
            }

            void Runing(CancellationToken cts)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested(); //throw an OperationCanceledException
                }

                Console.WriteLine("没被终止继续运行");
            }

            CancelTrigger();//触发终止所有用这个source的token的task
        }

        
    }
}
