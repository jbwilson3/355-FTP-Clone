#include <WinSock.h>

#define SCK_VERSION1		0x0101
#define SCK_VERSION2		0x0202

#define SOCK_STREAM			1
#define SOCK_DGRAM			2
#define SOCK_RAW			3

#define AF_INET				2

#define IPPROTO_TCP			6

//WSAData typedef
typedef struct WSAData
{
	WORD				wVersion;
	WORD				wHighVersion;
	char				szDescription[WSADESCRIPTION_LEN+1];
	char				szSystemStatus[WSASYS_STATUS_LEN+1];
	unsigned short		iMaxSockets;
	unsigned short		iMaxUdpDg;
	char *				lpVendorInfo;
} 
WSADATA;

typedef WSADATA *LPWSADATA;

//server address struct
struct sockAddr
{
	short family;
	u_short port;
	struct in_addr addr;
	char zero[8];
};


//function prototypes
//not really sure where these come from, I assume the functions will be added via the linker
int PASCAL WSAStartup(WORD,LPWSADATA);
int PASCAL WSACleanup(void);
SOCKET PASCAL socket(int,int,int);
int PASCAL closesocket(SOCKET);
int PASCAL connect(SOCKET, const struct sockaddr*, int);

//
//TCP SOCKET CLASS
//
class TCPSocket
{
private:
	SOCKET sHandle;					//socket handle
	sockaddr_in sockAddr;		//host address information

public:
	//winsock
	static bool WinsockIsRunning;
	static bool StartupWinsock();
	static void ShutdownWinsock();
	
	//member functions
	void setAddr(u_short port, struct in_addr sinAddr);
	bool connect();
	void disconnect();

};

//
//WINSOCK MANAGEMENT
//

//initialize to false (winsock starts off)
bool TCPSocket::WinsockIsRunning = false;

bool TCPSocket::StartupWinsock()
{
	//Start up Winsock
	WSADATA wsaData;

	int error = WSAStartup(0x0202, &wsaData);

	//Problems?
	if (error)
		return false;

	if (wsaData.wVersion != 0x0202)
	{
		WSACleanup();
		return false;
	}
	
	TCPSocket::WinsockIsRunning = true;

	return true;
}

void TCPSocket::ShutdownWinsock()
{
	TCPSocket::WinsockIsRunning = false;

	WSACleanup();
};


//
//TCPSOCKET MEMBER FUNCTIONS
//
void TCPSocket::setAddr(u_short port, struct in_addr addr)
{
	sockAddr.sin_family = AF_INET;
	sockAddr.sin_port = port;
	sockAddr.sin_addr = addr;

};

bool TCPSocket::connect()
{
}

void TCPSocket::disconnect()
{
}