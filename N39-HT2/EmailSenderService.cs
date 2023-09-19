namespace N39_HT2;

public class EmailSenderService
{
    public bool SendEmail(string emailAddres)
    {
        if(string.IsNullOrEmpty(emailAddres))
        {
            return false;
        }
        return true;
    }
}
