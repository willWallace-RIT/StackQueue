using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Stack queue (a stack that also function queue at the same time) created by Will Gardner a long time ago based on a stackoverflow  solution for making
//a queue out of a stack. 
//Mit liscense in git
public class StackQueue<T>
{
  //
  private Stack<T> inbox;
  private Stack<T> outbox;
  // Start is called before the first frame update
  public StackQueue(){
    inbox = new Stack<T>();
    outbox = new Stack<T>();
  }
  public StackQueue(StackQueue<T> sQ){
    inbox = new Stack<T>();
    outbox = sQ.CopyFullQueue(); 
    while(!(outbox.Count==0)){
      inbox.Push(outbox.Pop());
    }

  }
  public void push(T t){
    inbox.Push(t);
  }
  public void pushToFront(T t){
    while(!(inbox.Count==0)){
      outbox.Push(inbox.Pop());
    }
    outbox.Push(t); 
    while(!(outbox.Count==0)){
      inbox.Push(outbox.Pop());

    }
  }

  public T dequeueStack(int stackNum){
    Stack<T> stack = (stackNum==0)?inbox:outbox;
    Stack<T> tempStack = new Stack<T>();
    while(!(stack.Count==0)){
      tempStack.Push(stack.Pop());
    }
    T retVal = tempStack.Pop();
    while(!(tempStack.Count==0)){
      stack.Push(tempStack.Pop());
    }
    if(stackNum==0){
      inbox = stack;
    }
    else{
      outbox = stack;
    }
    return retVal;
  }
  public T dequeue(){
    while(!(inbox.Count==0)){
      outbox.Push(inbox.Pop());
    }
    T retVal = outbox.Pop();
    while(!(outbox.Count==0)){
      inbox.Push(outbox.Pop());
    }
    return retVal;
  }

  public int Count{get{return inbox.Count;}}
  public T pop(){
    return inbox.Pop();
  }
  //bottom value peak
  public T topQPeek(){

    while(!(inbox.Count==0)){
      outbox.Push(inbox.Pop());
    }
    T retVal = outbox.Peek();
    while(!(outbox.Count==0)){
      inbox.Push(outbox.Pop());
    }
    return retVal;
  }

  public T topQNPeek(int N){
    if(N ==1){
      return topQ2Peek();
    }else{

      if(Count>N){ 
        while(!(inbox.Count==0)){
          outbox.Push(inbox.Pop());
        }

        T retVal = default;
        for(int i = 0; i < N;i++){
          
         // Debug.Log(i);
          T temp1 = outbox.Pop();
          inbox.Push(temp1);
        }
        retVal = outbox.Peek();
        while(!(outbox.Count==0)){
          inbox.Push(outbox.Pop());
        }
       // Dibug.Log("Count:"+Count); 
        return retVal;
      }
      else{
        return default;
      }
    }
  }
  //second bottommost value Peek
  public T topQ2Peek(){
    if(Count>1){ 
      while(!(inbox.Count==0)){
        outbox.Push(inbox.Pop());
      }
      T temp1 = outbox.Pop();
      T retVal = outbox.Peek();
      outbox.Push(temp1);
      while(!(outbox.Count==0)){
        inbox.Push(outbox.Pop());
      }
      return retVal;
    }
    else{
      return default;
    }
  }
  //top most value
  public T topSPeek(){
    return inbox.Peek();
  }
  //second top most value peek

  public T topSPeekN(int N){
    if(N == 1){
      return topSPeek2();
    }
    else{

      if(Count<N){
        return default;
      }
      //T temp1 = default;
      T temp2 = default;
      for(int i = 0; i < N; i++){
        //Debug.Log(i);
        
        outbox.Push(inbox.Pop());
        temp2 = inbox.Peek();
        

      }
      while(!(outbox.Count==0)){
        inbox.Push(outbox.Pop());
      }

      //Debug.Log("Count:"+Count); 
      return temp2;

    }
  }

  public T topSPeek2(){
    if(Count<2){
      return default;
    }
    T temp1 = inbox.Pop();
    T temp2 = inbox.Peek();
    inbox.Push(temp1);
    return temp2;
  }
  public Stack<T> CopyFullQueue(){
    Stack<T> retStack = new Stack<T>(); 
    while(!(inbox.Count==0)){
      T temp = inbox.Pop();
      outbox.Push(temp);
      retStack.Push(temp);
    }
    while(!(outbox.Count==0)){
      inbox.Push(outbox.Pop());
    }
    return retStack;
  }
}
