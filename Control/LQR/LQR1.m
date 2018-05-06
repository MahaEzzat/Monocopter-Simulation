A=[0.8978 1.6108 0 0; 0 0 0.2237 -17.695; 0 0 -2.2649 1231.1; 0 0 -0.0063 0];
B=[ 114.35; 38.942; 0; -2.3455];
Q=[0.01 0 0 0;0 0.01 0 0;0 0 0.01 0;0 0 0 0.01];
R=1;
K=lqr(A,B,Q,R);
A2=A-B*K;
B2=[0;0;0;0];
D=0;
C=[0 1 0 0];
sys=ss(A2,eye(4), eye(4), eye(4));
t = 0:0.01:10;
x = initial(sys,[40;0;0;0],t);
x1 = [1 0 0 0]*x';
x2 = [0 1 0 0]*x';
x3 = [0 0 1 0]*x';
x4 = [0 0 0 1]*x';

subplot(2,2,1); plot(t,x1); grid
xlabel('t (sec)'); ylabel('x1')
subplot(2,2,2); plot(t,x2); grid
xlabel('t (sec)'); ylabel('x2')
subplot(2,2,3); plot(t,x3); grid
xlabel('t (sec)'); ylabel('x3')
subplot(2,2,4); plot(t,x4); grid
xlabel('t (sec)'); ylabel('x4')
