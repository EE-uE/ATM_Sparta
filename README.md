## 목차

---

- 프로젝트 소개
- 소개
- 기능

## 프로젝트 소개

---

- 프로젝트 이름 : ATM_Sparta
- 프로젝트 기간 : 2025.04.20~2025.04.25
- 개발 엔진 : Unity 2022.3.17f1
- 언어 : C#

## 소개

---

이 프로젝트는 **Unity UI**와 **JSON**을 활용한 **데이터 저장 기능 연습**을 위한 것입니다.

주요 기능으로는 사용자 **로그인, 회원가입, 입출금 시스템** 등이 있으며

JSON을 이용해 **유저 데이터를 저장하고 불러오는 기능**을 중점적으로 구현하였습니다.

## 기능

---

**메인 화면** 

ID, PW 입력 후 로그인 버튼을 클릭하면 입력된 사용자 정보를 불러오며 입출금 창으로 이동

입력 정보가 다를 시 팝업창으로 정보 확인 메세지가 뜨게 됨

정보가 없을 시 SIGN UP 버튼을 통해 회원가입 가능

![image](https://github.com/user-attachments/assets/be79a1cd-a1d8-41f5-bde1-e1e7cdc725a9)


**회원가입** 

중복되는 아이디가 있을 경우, 빈칸이 있을 경우, 패스워드가 다를 경우 각 상황에 맞는 에러 메세지가 출력되며

회원가입이 정상적으로 완료되었을 경우 “회원가입이 완료되었습니다.” 메세지 출력 및 완료

![image](https://github.com/user-attachments/assets/2bb79365-5aa1-4926-99e4-817172470ecb)

![image](https://github.com/user-attachments/assets/5258e694-7606-4c22-9e49-af08e2d3f25c)


**메인화면**

현금 및 계좌 잔고 확인이 가능하며 입/출/송금 버튼을 통해 원하는 내용 실행

![image](https://github.com/user-attachments/assets/6cb4c2fc-613b-455d-9916-2d479ee2c7bb)

**입/출금**

원하는 금액 버튼 입력 혹은 직접 입력칸에 원하는 금액을 기재 후 입/출금 버튼을 누르면 실시간으로 잔액 변동 UI로 확인 가능

![image](https://github.com/user-attachments/assets/e10234bc-1ae0-4735-8c6e-4a7f7992aaa1)


**송금**

송금대상(이름) 및 금액 입력 후 송금, 송금이 완료되었을 경우 완료 메세지가 뜨지만

잔액부족 및 송금대상이 없을 경우 에러 메세지 출력

![image](https://github.com/user-attachments/assets/d658519e-e1ec-4907-bffa-091fb1d104fd)



각 상황에 맞는 메세지 출력

![image](https://github.com/user-attachments/assets/c4a9a02a-60a9-45d1-bddd-b0bd4f961453)

![image](https://github.com/user-attachments/assets/9960a2a3-87e1-4b7a-ada2-d2bda63144f3)

![image](https://github.com/user-attachments/assets/35aec9e4-b774-4a41-a9a4-314c46465786)

