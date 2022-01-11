# myCPU

## prologue

코딩을 공부하다보니 명령을 내리는 컴퓨터에 대해 알고싶어졌다. 컴퓨터에서 무슨 일이 일어나는지 논리적으로 구현해보고자 한다.

## 프로젝트 목표

전기공학이 필요한 부분을 추상화 시키고 부울 연산과 논리게이트부터 ALU, 하드웨어 플랫폼을 코드로 구현해본다.

## 언어: 'C#'
추후 유니티 프로젝트를 함에 있어서 도움이 될 것으로 판단하였다.

## 기간: 하루에 2시간. 12주

## UI
유니티를 사용. 기능들을 GameObject로 구현.

### 참고 영상

1. Architecture All Access: Modern CPU Architecture by Intel Technology
	https://www.youtube.com/watch?app=desktop&v=vgPFzblBh7w
2. Computer Science by CrashCourse
	https://youtube.com/playlist?list=PL8dPuuaLjXtNlUrzyH5r6jN9ulIgZBpdo
3. Emulating a CPU in C++(6502) by Dave Poo
	https://www.youtube.com/watch?v=qJgsuQoy9bc&t=2s

### 참고 책

1. The Elements of Computing Systems 밑바닥부터 만드는 컴퓨팅 시스템 by Noam Nisan

## 기획

### 기능 

구현하고자 하는 기능은 Unity Editor, Unity Runtime 두 영역에서 동작한다.

#### Unity Editor

구현한 object(ex: prefab)를 쉽게 _생성_, _삭제_, _조합_을 할 수 있는 Editor Window.
1. _생성_ : 원하는 종류의 object를 생성할 수 있다.
2. _삭제_ : _선택_한 object를 삭제할 수 있다.
3. _조합_ : _선택_한 두 object를 _연결_하는 것을 말한다.

가시성을 위한 기능.
_선택_: 선택한 object 외곽이 하이라이트 처리가 된다. 선택의 방법은 마우스 클릭외 다른 방법이 있다.(미정) (보너스: 여러개를 선택, 선택 중인 object를 해제하는 기능)
_연결_: 연결 된 두 object 사이에 line이 생긴다. (보너스: 1대 다, 다대 1 괸계에서의 line 생성)

#### Runtime

1. 주기 : scene에 있는 object는 scene에서 지정한 동일한 주기대로 동작한다. 주기는 사용자가 설정할 수 있다.
2. 입출력 인터페이스 : 데이터 입출력을 위한 인터페이스. (보너스: 여러 연산을 처리하기)
3. 디버그 인터페이스 : 원하는 지점의 값을 알 수 있는 인터페이스. (보너스: 여러 지점의 값을 알 수 있기)

### Scene (미정)
